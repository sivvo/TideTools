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

class CEQIMInterface
{
public:
	CEQIMInterface(void)
	{
		m_EQIM=0;
	}
	~CEQIMInterface(void)
	{
	}

//	void GotChannelList(unsigned char *buf, int size);
//	void GotMessage(unsigned char *buf, int size);

	void AttachEQIM(void *pEQIM) {m_EQIM=pEQIM;}
	void *m_EQIM;

	/* LOGIN PROCESS */
	virtual void GotLoginRsp(bool Success) {}
	virtual void GotWorldRsp(char *Characters) {}
	virtual void GotValidateRsp(bool Success) {}
	virtual void GotUnknownRsp(char *Response) {}

	/* OTHER */
	virtual void GotDisconnect(bool ServerAction=false) {}

	/* CHAT STUFF */
	virtual void GotBuddyStatus(char *buddy, int Status) {}
	virtual void GotChannelMessage(char *user, char *channel, char *message) {}
	virtual void GotTell(char *user, char *message) {}
	virtual void GotTellEcho(char *user, char *message) {}
	virtual void GotMessage(char *message) {}
	virtual void GotMessage(int code, char *user, char *channel, char *other) {}
	virtual void GotPart(char *user, char *channel) {}
	virtual void GotJoin(char *user, char *channel) {}

	virtual void GotJoinChannel(char *channel) {}
	virtual void GotPartChannel(char *channel) {}

	virtual void GotChannelMemberStatus(char *channel, char *user, ChannelMemberStatus OldStatus, ChannelMemberStatus Status) {}

	virtual void GotChannelsUpdate() {}
	virtual void GotChannelMembersUpdate(char *channel) {}


	virtual void ChatReady() {}
	virtual void ChatConnected() {}
	virtual void ChatValidated(bool Success) {}
	virtual void ChatReconnect() {}
	virtual void LoginReady() {}
	virtual void LoginConnected() {}

	virtual void Pulse() {}
};
