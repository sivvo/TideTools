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

// login states

// - Not yet connected
#define LOGIN_PRECONNECT 0

// - Connected, waiting to log in
#define LOGIN_CONNECTED  1

// - Logged in, eligible for character lists and validation
#define LOGIN_LOGGEDIN   2

// - Character Validated
#define LOGIN_VALIDATED  3

// - Login Completed & Disconnected
#define LOGIN_COMPLETE   4

class CEQIMLogin
{
public:
	CEQIMLogin(void *pEQIM);
	~CEQIMLogin(void);

	void ProcessIncomingData(unsigned char *buf, int size);
	void ProcessLoginResponse(char *buf, int size);
	int CreateOutgoingPacket(unsigned char *buf);

	void GotLoginRsp(char *buf);
	void GotWorldRsp(char *buf);
	void GotValidateRsp(char *buf);

	void TryLogin(const char *name, const char *pass);
	void TryLoginPreEncrypted(const char *name, const char *pass);
	void ListChars(const char *servername);
	void TryValidate(const char *servername, const char *name);
	void SendCommandf(const char *format,...);
	void SendCommandfNo0(const char *format,...);

	void BeginLogin();

	void *m_EQIM;

//	bool KillLoginThread;
//	bool LoginThreading;
//	bool LoginReady;

	CThread LoginThread;

	int LoginState;
};

