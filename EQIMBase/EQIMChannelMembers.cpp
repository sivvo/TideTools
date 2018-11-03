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
#include "EQIMChannelMembers.h"
#include "EQIMInterface.h"
#define Interface ((CEQIMInterface*)(EQIM->m_Interface))
#define EQIM ((CEQIM*)m_EQIM)

CEQIMChannelMembers::CEQIMChannelMembers(void)
{
	Members=0;
	m_EQIM=0;
	Updating=false;
}

CEQIMChannelMembers::~CEQIMChannelMembers(void)
{
	Clear();
}

void CEQIMChannelMembers::Clear()
{
	CLock L(&S,true);
	while(Members)
	{
		RemoveMember(Members);
	}
}

void CEQIMChannelMembers::AddMember(const char *Name, ChannelMemberStatus Status)
{
	CLock L(&S,true);
	ChannelMemberNode *node=FindMemberNode(Name);
//	char out[256];
	if (node)
	{
		if (node->Member.Status!=Status)
		{
//			sprintf(out,"Updating channel member %s status\n",node->Member.FullName);
//			EQIM->Debug.Log(out);
			Interface->GotChannelMemberStatus(ChannelName, node->Member.FullName, node->Member.Status,Status);
			node->Member.Status=Status;
		}
		return;
	}
	node=new ChannelMemberNode;
	node->Member.Status=Status;
	if (strchr(Name,'.'))
		strcpy(node->Member.FullName,Name);
	else
		sprintf(node->Member.FullName,"%s.%s",EQIM->sServer,Name);
//	sprintf(out,"Adding channel member %s\n",node->Member.FullName);
//	EQIM->Debug.Log(out);
	node->pNext=Members;
	node->pLast=0;
	if (Members)
		Members->pLast=node;
	Members=node;
}

void CEQIMChannelMembers::AutoOpMember(const char *Name, bool AutoOp)
{
	ChannelMemberNode *node=FindMemberNode(Name);
	if (node)
	{
		node->Member.AutoOp=AutoOp;
	}
}

ChannelMemberNode *CEQIMChannelMembers::FindMemberNode(const char *Name)
{// private, no lock
//	char out[256];
//	sprintf(out,"FindMemberNode(%s)\n",Name);
//	EQIM->Debug.Log(out);
	if (!Name)
		return 0;
	ChannelMemberNode *node=Members;
	while(node)
	{
		if (!stricmp(Name,node->Member.FullName))
			return node;
		node=node->pNext;
	}
	return 0;
}

void CEQIMChannelMembers::RemoveMember(ChannelMemberNode *node)
{
	if (!node)
		return;
	CLock L(&S,true);
	if (node->pNext)
		node->pNext->pLast=node->pLast;
	if (node->pLast)
		node->pLast->pNext=node->pNext;
	else
		Members=node->pNext;
	delete node;
}

bool CEQIMChannelMembers::FindMember(const char *Name, EQIMChannelMember &Dest)
{
//	char out[256];
//	sprintf(out,"FindMember(%s)\n",Name);
//	EQIM->Debug.Log(out);
	if (!Name)
		return false;
	ChannelMemberNode *node=Members;
	while(node)
	{
		if (!stricmp(Name,node->Member.FullName))
		{
			Dest=node->Member;
			return true;
		}
		node=node->pNext;
	}
	return false;
}

bool CEQIMChannelMembers::UpdateMembers(const char *list)
{
	CLock L(&S,true);
	ChannelMemberNode *node=Members;
	char Buffer[2048]={0};
	strcpy(Buffer,list);
	char *token=0;
	token=strtok(Buffer,",");
	ChannelMemberStatus Status=CM_GONE;
	while(token)
	{
		while(token[0]==' ') token++;
		switch(token[0])
		{
		case '*':
			Status=CM_OWNER;
			token++;
			break;
		case '@':
			Status=CM_OP;
			token++;
			break;
		case '+':
			Status=CM_VOICE;
			token++;
			break;
		default:
			Status=CM_NORMAL;
			break;
		}
		AddMember(token,Status);
		Updating++;
		token=strtok(NULL,",");
	}
	if (Updating>=UpdateCount)
	{
		EndUpdateMembers();
		Interface->GotChannelMembersUpdate(ChannelName);
		return true;
	}
	return false;
}

void CEQIMChannelMembers::BeginUpdateMembers(unsigned long NewCount)
{
//	EQIM->Debug.Log("BeginUpdateMembers()\n");
	CLock L(&S,true);
	UpdateCount=NewCount;
	ChannelMemberNode *node=Members;
	while(node)
	{
		node->Member.Status=CM_GONE;
		node=node->pNext;
	}
}

bool CEQIMChannelMembers::UpdateAutoOps(const char *list)
{
	CLock L(&S,true);
	ChannelMemberNode *node=Members;
	char Buffer[2048]={0};
	strcpy(Buffer,list);
	char *token=0;
	token=strtok(Buffer,",");
	ChannelMemberStatus Status=CM_GONE;
	while(token)
	{
		while(token[0]==' ') token++;
		AutoOpMember(token);
		token=strtok(NULL,",");
	}
	return false;
}


void CEQIMChannelMembers::BeginUpdateAutoOps()
{
	CLock L(&S,true);
	ChannelMemberNode *node=Members;
	while(node)
	{
		node->Member.AutoOp=false;
		node=node->pNext;
	}
}

void CEQIMChannelMembers::EndUpdateMembers()
{
//	EQIM->Debug.Log("EndUpdateMembers()\n");
	Updating=0;
	ChannelMemberNode *node=Members;
	while(node)
	{
		if (node->Member.Status==CM_GONE)
		{
			ChannelMemberNode *next=node->pNext;
			RemoveMember(node);
			node=next;
			continue;
		}
		else
		{
//			char out[256];
//			sprintf(out,"Channel Member: %s - %d\n",node->Member.FullName,node->Member.Status);
//			EQIM->Debug.Log(out);
		}
		node=node->pNext;
	}
}

void CEQIMChannelMembers::RemoveMember(const char *Name)
{
	CLock L(&S,true);
	ChannelMemberNode *node=FindMemberNode(Name);
	if (node)
	{
//		char out[256];
//		sprintf(out,"Removing Channel Member: %s\n",node->Member.FullName);
//		EQIM->Debug.Log(out);
		RemoveMember(node);
	}
}

void CEQIMChannelMembers::SetOwner(const char *Name)
{
	CLock L(&S,true);
	ChannelMemberNode *node=FindMemberNode(Name);
	if (node)
	{
		if (node->Member.Status!=CM_OWNER)
		{
//			EQIM->Debug.Logf("Updating channel member %s status\n",node->Member.FullName);
			node->Member.Status=CM_OWNER;
		}
	}
}

