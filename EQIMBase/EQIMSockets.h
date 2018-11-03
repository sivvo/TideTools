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
#ifdef WIN32

#include "winsock2.h"
#ifndef SD_BOTH
#define SD_BOTH 0x02
#endif

#else
// LINUX
//#include "../EQIMBase/stdafx.h"
#endif

#include "EQIMStructs.h"



class CEQIMSockets
{
public:
	CEQIMSockets(void *pEQIM);
	~CEQIMSockets(void);

	int SendTo(const char *buf,  int len);//,  const struct sockaddr FAR *to,int tolen);
	int RecvFrom(char * buf, int len);//, struct sockaddr FAR *from, int FAR *fromlen);
	void ShutDown();
	bool Initialize(unsigned short clientport, const char *serveraddress, unsigned short serverport);

	bool IsData();

	unsigned short CRC16(unsigned char *buf, int size, bool Outgoing=true);

	bool bValid;
	bool bDisconnected;
	
	bool bDecode;

	SOCKET s;
	Addr Client;
	Addr Server;


	void *m_EQIM;
};
