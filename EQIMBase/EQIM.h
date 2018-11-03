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
#include "stdafx.h"
#include "EQIMSockets.h"
#include "EQIMSequencer.h"
#include "EQIMProcessor.h"
#include "EQIMEncoder.h"
#include "EQIMDebug.h"
#include "EQIMStructs.h"
#include "EQIMLogin.h"
#include "EQIMChannelMembers.h"
#include "EQIMChannels.h"
#include "EQIMBuddies.h"
#include "Queue.h"

#define BUDDY_REMOVED   0
#define BUDDY_OFFLINE   1
#define BUDDY_EQIM      2
#define BUDDY_EQIMAFK   3
#define BUDDY_ONLINE    5
#define BUDDY_ONLINEAFK 6

#define EQIMBaseVersion "2004.12.15"

class CEQIM
{
public:
	CEQIM(void);
	~CEQIM(void);

	static inline const char *Version() {return EQIMBaseVersion;}

	bool BeginChat();
	bool CloseSession();
	bool InitializeSession(unsigned long number);
	bool OldLogin();

	void EndSession();

	inline void AttachInterface(void *pInterface) {m_Interface=pInterface;}

//	int CreateOutgoingPacket(unsigned char *buf);
	bool CreateOutgoingPacket(_Data &Out);

	void GotDisconnect(bool ServerAction=false);
	void GotSessionInfo(in_session* session);
	void Validate();
	bool CEQIM::SendBuffer(unsigned char *str, int size);
	bool CEQIM::SendCommand(const char *str);
	bool CEQIM::SendCommandf(const char *format,...);

	void CEQIM::KeepAlive();

	char sServer[64];
	char sCharacter[64];

	char sStationName[64];
	char sPassword[64];

	Addr Server;
	Addr Client;
	_Validated Validated;

	unsigned long SessionNumber;
	bool bValidated;
	unsigned short LocalPort;

	CEQIMSockets Socket;
	CEQIMSequencer Sequencer;
	CEQIMEncoder Encoder;
	CEQIMProcessor Processor;
	CEQIMDebug Debug;
	CEQIMLogin Login;
	CEQIMChannels Channels;
	CEQIMBuddies Buddies;
	void *m_Interface;


	Queue<_Data> Outgoing;

//	bool ChatThreading;
//	bool KillChatThread;
//	bool ChatReady;
	CThread ChatThread;

	bool Disconnected;

	
	EQIMServer ServerType;
};
