/*****************************************************************************
    EQIMBase, the Base C++ classes for handling EQIM
    Copyright (C) 2003-2004 Lax

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License, version 2, 
    as published by the Free Software Foundation.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    Usage of these EQIM clients and derivatives subject you to the rules of
    the EQIM network.  Access to the network is restricted to paying 
    subscribers of the online game EverQuest.  This software and the EQIM
    protocol is provided in good faith to the EverQuest community, and not 
    intended for malicious purposes.  Usage of this software for malicious
    purposes is prohibited and any distribution, usage, or mention of
    malicious activity can and will be reported to the administrators of the
    EQIM network.
******************************************************************************/

// Current Porting Issues:
// None known at this time

#include "EQIM.h"
#include "EQIMChannels.h"
#include "EQIMInterface.h"
#define Interface ((CEQIMInterface*)(EQIM->m_Interface))
#define EQIM ((CEQIM*)m_EQIM)
//#define DebugTry(x) EQIM->Debug.Logf("Trying %s\n",#x);x;EQIM->Debug.Logf("%s complete\n",#x)
#define DebugTry(x) x

CEQIMChannels::CEQIMChannels(void *pEQIM)
{
	Channels=0;
	Count=0;
	m_EQIM=pEQIM;
}

CEQIMChannels::~CEQIMChannels(void)
{
	CLock L(&S,true);
	while(Channels)
	{
		RemoveChannel(Channels);
	}
}

void CEQIMChannels::RemoveChannel(ChannelNode *node)
{
	if (!node)
		return;
	if (Interface)
		Interface->GotPartChannel(node->Channel.FullName);
	CLock L(&S,true);
	if (node->pNext)
		node->pNext->pLast=node->pLast;
	if (node->pLast)
		node->pLast->pNext=node->pNext;
	else
		Channels=node->pNext;
	delete node;
}

void CEQIMChannels::AddChannel(unsigned long Number, const char *Name)
{	
	DebugTry(CLock L(&S,true));
	DebugTry(ChannelNode *node=FindChannelNodeInternal(Name));
	if (node)
	{
		node->Channel.Number=Number;
		return;
	}
	node=new ChannelNode;
	node->Channel.Moderated=false;
	node->Channel.LastUpdate=0;
	node->Channel.LastUpdateTry=0;
	node->Members.m_EQIM=m_EQIM;
	node->Channel.Number=Number;
	if (strchr(Name,'.'))
		strcpy(node->Channel.FullName,Name);
	else
		sprintf(node->Channel.FullName,"%s.%s",EQIM->sServer,Name);
	strcpy(node->Members.ChannelName,node->Channel.FullName);
	node->pNext=Channels;
	node->pLast=0;
	if (Channels)
		Channels->pLast=node;
	Channels=node;
	DebugTry(Interface->GotJoinChannel(node->Channel.FullName));
}

ChannelNode *CEQIMChannels::FindChannelNodeInternal(const char *Name)
{
	if (!Name)
		return 0;
	char name[256];
	if (strchr(Name,'.'))
		strcpy(name,Name);
	else
		sprintf(name,"%s.%s",EQIM->sServer,Name);
	ChannelNode *node=Channels;
	while(node)
	{
		if (!stricmp(name,node->Channel.FullName))
			return node;
		node=node->pNext;
	}
	return 0;
}

ChannelNode *CEQIMChannels::FindChannelNode(const char *Name)
{
	if (!Name)
		return 0;
//	EQIM->Debug.Logf("FindChannelNode(%s)\n",Name);
	char name[256];
	if (strchr(Name,'.'))
		strcpy(name,Name);
	else
		sprintf(name,"%s.%s",EQIM->sServer,Name);

	CLock L(&S,true);
	ChannelNode *node=Channels;
	while(node)
	{
		if (!stricmp(name,node->Channel.FullName))
			return node;
		node=node->pNext;
	}
//	EQIM->Debug.Log("Channel not found\n");
	return 0;
}

bool CEQIMChannels::FindChannel(const char *Name, EQIMChannel &Dest)
{
	if (!Name)
		return false;
	char name[256];
	if (strchr(Name,'.'))
		strcpy(name,Name);
	else
		sprintf(name,"%s.%s",EQIM->sServer,Name);
	CLock L(&S,true);
	ChannelNode *node=Channels;
	while(node)
	{
		if (!stricmp(Name,node->Channel.FullName))
		{
			Dest=node->Channel;
			return true;
		}
		node=node->pNext;
	}
	return false;
}

void CEQIMChannels::UpdateChannels(const char *list)
{
	DebugTry(CLock L(&S,true));
	ChannelNode *node=Channels;
	while(node)
	{
		node->Channel.Number=0;
		node=node->pNext;
	}

	char Buffer[2048]={0};
	strcpy(Buffer,list);
	char *token=0;
	token=strtok(Buffer,",");
	unsigned long Num=0;
	while(token)
	{
		Num++;
		DebugTry(AddChannel(Num,token));
		token=strtok(NULL,",");
	}
	Count=Num;

	node=Channels;
	while(node)
	{
		if (node->Channel.Number==0)
		{
			ChannelNode *next=node->pNext;
			DebugTry(RemoveChannel(node));
			node=next;
			continue;
		}
		node=node->pNext;
	}
	EQIM->Debug.Log("UpdateChannels() returning\n");
}

void CEQIMChannels::AddChannelMember(const char *Channel, const char *Member, ChannelMemberStatus Status)
{
	CLock L(&S,true);
	ChannelNode *node=FindChannelNodeInternal(Channel);
	if (node)
	{
		node->Members.AddMember(Member,Status);
	}
}

void CEQIMChannels::RemoveChannelMember(const char *Channel, const char *Member)
{
	CLock L(&S,true);
	ChannelNode *node=FindChannelNodeInternal(Channel);
	if (node)
	{
		node->Members.RemoveMember(Member);
	}
}

bool CEQIMChannels::FindChannelMember(const char *Channel, const char *Member, EQIMChannelMember &Dest)
{
	CLock L(&S,true);
	ChannelNode *node=FindChannelNodeInternal(Channel);
	if (node)
	{
		return node->Members.FindMember(Member,Dest);
	}
	return false;
}

