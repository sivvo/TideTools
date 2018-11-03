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

#pragma once
#include "EQIMStructs.h"

struct BuddyNode
{
	EQIMBuddy Buddy;
	BuddyNode *pNext;
	BuddyNode *pLast;
};

class CEQIMBuddies
{
public:
	CEQIMBuddies(void *);
	~CEQIMBuddies(void);

	void Clear();

	void AddBuddy(const char *name, unsigned char Status);
	void RemoveBuddy(const char *name);
	bool FindBuddy(const char *name, EQIMBuddy &Dest);
	BuddyNode *FindBuddyNodeInternal(const char *name);

	void *m_EQIM;

	BuddyNode *Buddies;
	CSemaphore S;
};
