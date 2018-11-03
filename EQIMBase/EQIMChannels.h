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


struct ChannelNode
{
	EQIMChannel Channel;
	CEQIMChannelMembers Members;
	ChannelNode *pNext;
	ChannelNode *pLast;
};

class CEQIMChannels
{
public:
	CEQIMChannels(void *);
	~CEQIMChannels(void);


	void AddChannelMember(const char *Channel, const char *Member, ChannelMemberStatus Status);
	void RemoveChannelMember(const char *Channel, const char *Member);
	bool FindChannelMember(const char *Channel, const char *Member, EQIMChannelMember &Dest);

	void AddChannel(unsigned long Number, const char *Name);
	void RemoveChannel(ChannelNode *node);

	ChannelNode *FindChannelNode(const char *Name);
	bool FindChannel(const char *Name, EQIMChannel &Dest);
	void UpdateChannels(const char *list);

	ChannelNode *Channels;
//	CCriticalSection S;
	CSemaphore S;

	unsigned long Count;
	void *m_EQIM;

	ChannelNode *FindChannelNodeInternal(const char *Name);
private:
};
