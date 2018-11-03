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

struct ChannelMemberNode
{
	EQIMChannelMember Member;
	ChannelMemberNode *pLast;
	ChannelMemberNode *pNext;
};

class CEQIMChannelMembers
{
public:
	CEQIMChannelMembers(void);
	~CEQIMChannelMembers(void);

	void Clear();
	void AddMember(const char *Name, ChannelMemberStatus Status);
	bool FindMember(const char *Name, EQIMChannelMember &Dest);

	void RemoveMember(const char *Name);

	void SetOwner(const char *Name);

	void BeginUpdateMembers(unsigned long Total);
	bool UpdateMembers(const char *list);

	void BeginUpdateAutoOps();
	bool UpdateAutoOps(const char *list);
	void AutoOpMember(const char *Name, bool AutoOp=true);

	char ChannelName[128];
	ChannelMemberNode *Members;
	CSemaphore S;

	unsigned long Count;
	void *m_EQIM;
	unsigned long Updating;
	unsigned long UpdateCount;

private:

	ChannelMemberNode *FindMemberNode(const char *Name);
	void RemoveMember(ChannelMemberNode *node);
	void EndUpdateMembers();
};
