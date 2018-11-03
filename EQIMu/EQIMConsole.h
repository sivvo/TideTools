/*****************************************************************************
    TEQIM, EQIMd and EQIMu
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
#include "../EQIMBase/EQIMInterface.h"
#include "../EQIMBase/EQIM.h"

#define MODE_NONE    0
#define MODE_LOGIN   1
#define MODE_PRECHAT 2
#define MODE_CHAT    3

#define MSG_LOGINREADY     1
#define MSG_LOGINCONNECTED 2 
#define MSG_LOGGEDIN       3
#define MSG_LOGINFAILED    4
#define MSG_LOGINCOMPLETE  5
#define MSG_CHATREADY      6
#define MSG_CHATCONNECTED  7
#define MSG_CHATRECONNECT  8 
#define MSG_CHATVALIDATED  9

class	TidePlugin;
class	ItemPlugin;

struct Char
{
	char Name[128];
};

class _ConsoleData
{
public:
	_ConsoleData() {}
	_ConsoleData(char *val) {strcpy(Data,val);};
	char Data[1024];
	const _ConsoleData &operator=(char *val) {strcpy(Data,val);};
};

class CEQIMConsole: public CEQIMInterface
{
public:
	CEQIMConsole(void);
	~CEQIMConsole(void);

//	bool Threading;
//	bool KillThread;

	TidePlugin* TP;
	ItemPlugin* IP;

	void Go();

	void NoneCommand(const char * Command);
	void ChatCommand(const char * Command);
	void LoginCommand(const char * Command);
	void PreChatCommand(const char * Command);
	void CommonCommand(const char * Command);

	bool IsCharacter(const char *Name);

	void DoLogin(const char * Command);
	void DoPort(const char * Command);

	void Out(const char * Data);
	void Outf(const char *szFormat,...);
	
	Queue<unsigned long> Msgs;
	Queue<_ConsoleData> Display;

	int Mode;
	bool Echo;
	bool Password;

//	CWinThread *ConsoleThread;
	CThread ConsoleThread;

	Char Characters[10];

	clock_t LastSend;


/* CALLBACKS */
	void LoginReady();
	void LoginConnected();
	void GotLoginRsp(bool Success);
	void GotWorldRsp(char *Reponse);
	void GotValidateRsp(bool Success);


	void ChatReady();
	void ChatConnected();
	void ChatValidated(bool Success);
	void ChatReconnect();


	void GotBuddyStatus(char *buddy, int Status);
	void GotChannelMessage(char *user, char *channel, char *message);
	void GotTell(char *user, char *message);
	void GotTellEcho(char *user, char *message);
	void GotMessage(char *message);
	void GotChannelsUpdate();
	void GotPart(char *user, char *channel);
	void GotJoin(char *user, char *channel);
    
	void GotDisconnect(bool ServerAction);
};


