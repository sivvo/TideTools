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

#include "stdafx.h"
#include "EQIMBuddies.h"
#include "EQIM.h"
#include "EQIMInterface.h"
#define Interface ((CEQIMInterface*)(EQIM->m_Interface))
#define EQIM ((CEQIM*)m_EQIM)


CEQIMBuddies::CEQIMBuddies(void *pEQIM)
{
	m_EQIM=pEQIM;
	Buddies=0;
}

CEQIMBuddies::~CEQIMBuddies(void)
{
	Clear();
}

void CEQIMBuddies::Clear()
{
	CLock L(&S,true);
	while(Buddies)
	{
		BuddyNode *next=Buddies->pNext;
		delete Buddies;
		Buddies=next;
	}
}

void CEQIMBuddies::AddBuddy(const char *name, unsigned char Status)
{
//	EQIM->Debug.Logf("AddBuddy(%s)\n",name);
	if (!name)
		return;
	if (Status==BUDDY_REMOVED)
	{
		RemoveBuddy(name);
		return;
	}
	char FullName[256];
	if (strchr(name,'.'))
		strcpy(FullName,name);
	else
		sprintf(FullName,"%s.%s",EQIM->sServer,name);
	CLock L(&S,true);
	BuddyNode *node=FindBuddyNodeInternal(FullName);
	if (node)
	{
		if (node->Buddy.Status!=Status)
		{
			node->Buddy.Status=Status;
		}
		return;
	}
	node = new BuddyNode;
	node->pNext=Buddies;
	node->pLast=0;
	strcpy(node->Buddy.FullName,FullName);
	node->Buddy.Status=Status;
	if (Buddies)
		Buddies->pLast=node;
	Buddies=node;
}

void CEQIMBuddies::RemoveBuddy(const char *name)
{
//	EQIM->Debug.Logf("RemoveBuddy(%s)\n",name);
	if (!name)
		return;
	char FullName[256];
	if (strchr(name,'.'))
		strcpy(FullName,name);
	else
		sprintf(FullName,"%s.%s",EQIM->sServer,name);
	CLock L(&S,true);
	BuddyNode *node = Buddies;
	while(node)
	{
		if (!stricmp(node->Buddy.FullName,FullName))
		{
			if (node->pNext)
				node->pNext->pLast=node->pLast;
			if (node->pLast)
				node->pLast->pNext=node->pNext;
			else
				Buddies=node->pNext;
			delete node;
			return;
		}
		node=node->pNext;
	}
}

bool CEQIMBuddies::FindBuddy(const char *name, EQIMBuddy &Dest)
{
	if (!name)
		return false;
	char FullName[256];
	if (strchr(name,'.'))
		strcpy(FullName,name);
	else
		sprintf(FullName,"%s.%s",EQIM->sServer,name);
	CLock L(&S,true);
	BuddyNode *node = Buddies;
	while(node)
	{
		if (!stricmp(node->Buddy.FullName,FullName))
		{
			Dest=node->Buddy;
			return true;
		}
		node=node->pNext;
	}
	return false;
}

BuddyNode *CEQIMBuddies::FindBuddyNodeInternal(const char *name)
{
	char FullName[256];
	if (strchr(name,'.'))
		strcpy(FullName,name);
	else
		sprintf(FullName,"%s.%s",EQIM->sServer,name);

	BuddyNode *node = Buddies;
	while(node)
	{
		if (!stricmp(node->Buddy.FullName,FullName))
		{
			return node;
		}
		node=node->pNext;
	}
	return 0;
}

