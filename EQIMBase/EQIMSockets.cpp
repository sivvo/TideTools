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
// None

#include "stdafx.h"
#include "EQIMSockets.h"
#include "IntArray.h"
#include "EQIM.h"



#define EQIM ((CEQIM*)m_EQIM)

// #define DEBUG_CRC 1
// #define DEBUG_SOCKETS 1

CEQIMSockets::CEQIMSockets(void *pEQIM)
{
	bValid=false;
	bDecode=false;
	bDisconnected=true;
	s=INVALID_SOCKET;
	m_EQIM=pEQIM;
}

CEQIMSockets::~CEQIMSockets(void)
{
	ShutDown();
}

void CEQIMSockets::ShutDown()
{
	if (bValid)
	{
		shutdown(s,SD_BOTH);
		closesocket(s);
		s=INVALID_SOCKET;
		bValid=false;
		bDisconnected=true;
	}
}

unsigned short CEQIMSockets::CRC16(unsigned char *buf, int size, bool Outgoing)
{
	unsigned long CRC=0;
	struct ABCD
	{
		unsigned char a;
		unsigned char b;
		unsigned char c;
		unsigned char d;
	} ulDecodeKey;

	if (Outgoing)
		*(unsigned long*)&ulDecodeKey=EQIM->Encoder.DecodeKey;
	else
		*(unsigned long*)&ulDecodeKey=EQIM->Encoder.EncodeKey;


#ifdef DEBUG_CRC
	CString sTemp;
	sTemp.Format("Generating CRC16, key 0x%08X",ulDecodeKey);
	EQIM->Debug.LogBuffer((char *)buf,size,sTemp);
#endif

	
//		mov al, byte ptr [ulDecodeKey];
	int eax=ulDecodeKey.a;
//		mov edx, [ulDecodeKey+1];
	// signed because later the SAR operation is used rather than SHR
	int edx=ulDecodeKey.b; 
//		not al;
	eax=~eax;
//		and eax, 0xFF;
	eax&=0xFF;
//		and edx, 0xFF;
	edx&=0xFF;
//		mov eax, IntArray[eax*4];
	eax=IntArray[eax];
//		xor eax, 0xFFFFFF;
	eax^=0xFFFFFF;
//		mov ecx, eax;
	int ecx=eax;
//		and ecx, 0xFF;
	ecx&=0xFF;
//		xor ecx, edx;
	ecx^=edx;
//		mov edx, [ulDecodeKey+2];
	edx=ulDecodeKey.c;
//		sar eax, 8;
	eax>>=8;
//		mov ecx, IntArray[ecx*4];
	ecx=IntArray[ecx];
//		and eax, 0xFFFFFF;
	eax&=0xFFFFFF;
//		xor ecx, eax;
	ecx^=eax;
//		and edx, 0xFF;
	edx&=0xFF;
//		mov eax, ecx;
	eax=ecx;
//		and eax, 0xFF;
	eax&=0xFF;
//		xor eax, edx;
	eax^=edx;
//		sar ecx, 8;
	ecx>>=8;
//		mov edx, IntArray[eax*4];
	edx=IntArray[eax];
//		and ecx, 0xFFFFFF;
	ecx&=0xFFFFFF;
//		xor edx, ecx;
	edx^=ecx;
//		mov ecx, [ulDecodeKey+3]
	ecx=ulDecodeKey.d;
//		mov eax, edx;
	eax=edx;
//		and ecx, 0xFF;
	ecx&=0xFF;
//		and eax, 0xFF;
	eax&=0xFF;
//		xor eax, ecx;
	eax^=ecx;
//		sar edx, 8;
	edx>>=8;
//		mov eax, IntArray[eax*4];
	eax=IntArray[eax];
//		and edx, 0xFFFFFF;
	edx&=0xFFFFFF;
//		xor eax, edx;
	eax^=edx;
//		mov [CRC], eax;
	CRC=eax;
/*
	EQIM->Debug.Logf("CRC non-asm: 0x%08X\n",CRC);

	
	__asm{
		push eax;
		push ecx;
		push edx;
		mov al, byte ptr [ulDecodeKey];
		mov edx, [ulDecodeKey+1];
		not al;
		and eax, 0xFF;
		and edx, 0xFF;
		mov eax, IntArray[eax*4];
		xor eax, 0xFFFFFF;
		mov ecx, eax;
		and ecx, 0xFF;
		xor ecx, edx;
		mov edx, [ulDecodeKey+2];
		sar eax, 8;
		mov ecx, IntArray[ecx*4];
		and eax, 0xFFFFFF;
		xor ecx, eax;
		and edx, 0xFF;
		mov eax, ecx;
		and eax, 0xFF;
		xor eax, edx;
		sar ecx, 8;
		mov edx, IntArray[eax*4];
		and ecx, 0xFFFFFF;
		xor edx, ecx;
		mov ecx, [ulDecodeKey+3]
		mov eax, edx;
		and ecx, 0xFF;
		and eax, 0xFF;
		xor eax, ecx;
		sar edx, 8;
		mov eax, IntArray[eax*4];
		and edx, 0xFFFFFF;
		xor eax, edx;
		mov [CRC], eax;



		pop edx;
		pop ecx;
		pop eax;
	}
	EQIM->Debug.Logf("CRC asm: 0x%08X\n",CRC);
/**/

	int Temp=CRC;
#ifdef DEBUG_CRC
	sTemp.Format("CEQIMSockets::CRC16(): Temp %d\n",Temp);
	EQIM->Debug.Log(sTemp);
#endif// DEBUG_CRC

	for (int i = 0 ; i < size ; i++)
	{

		Temp = buf[i] ^ (CRC&0xFF);
		CRC = CRC >> 8;
//		CRC = CRC & 0xFFFFFF;
		CRC = IntArray[Temp] ^ CRC;
	}
	
	return (unsigned short)((~CRC)&0xFFFF);
}

int CEQIMSockets::SendTo(const char *buf,  int len)//,  const struct sockaddr FAR *to,int tolen)
{
	if (s==INVALID_SOCKET)
		return 0;
	int ret= sendto(s,buf,len,0,(sockaddr*)&Server,sizeof(Addr));
//	if (ret>0)
//	{
//		EQIM->Debug.LogBuffer(buf,ret,"CEQIMSockets::SendTo()");
//	}
	return ret;
}

int CEQIMSockets::RecvFrom(char * buf, int len)//, struct sockaddr FAR *from, int FAR *fromlen)
{
	if (s==INVALID_SOCKET)
		return 0;
	struct sockaddr from;
	int fromlen=sizeof(sockaddr);
	int ret = recvfrom(s,buf,len,0,&from,(socklen_t*)&fromlen);
/*
#ifdef DEBUG_SOCKETS
	if (ret>0)
	{
		EQIM->Debug.LogBuffer(buf,ret,"CEQIMSockets::RecvFrom()");
	}
#endif
/**/
	return ret;
}

bool CEQIMSockets::IsData()
{
	unsigned long result=0;
	if (ioctlsocket(s,FIONREAD,&result)==SOCKET_ERROR)
	{
		bDisconnected=true;
		bValid=false;
		// Disconnect
	}
	return (result>0);
}


bool CEQIMSockets::Initialize(unsigned short clientport, const char *serveraddress, unsigned short serverport)
{
	EQIM->Debug.Logf("CEQIMSockets::Initialize(): client port: %d  server: %s %d\n",clientport,&serveraddress[0],serverport);
	ShutDown();
	s=socket(2,SOCK_DGRAM,0); // initialize socket
	if (s==INVALID_SOCKET)
	{
		EQIM->Debug.Log("CEQIMSockets::Initialize(): socket() failed\n");
		return false;
	}
	int NonBlocking=1;
	if (ioctlsocket(s,FIONBIO,(u_long*)&NonBlocking)==SOCKET_ERROR) // set socket to non blocking
	{
		EQIM->Debug.Log("CEQIMSockets::Initialize(): Non-blocking failed\n");
		shutdown(s,SD_BOTH);
		closesocket(s);
		s=INVALID_SOCKET;
		bValid=false;
		bDisconnected=true;
		return false;
	}
	memset(&Client,0,sizeof(Addr));
	memset(&Server,0,sizeof(Addr));
	Client.sa_family=2;
	Client.Port=htons(clientport);
	if (bind(s,(const sockaddr*)&Client,sizeof(Addr))==SOCKET_ERROR)
	{
		EQIM->Debug.Log("CEQIMSockets::Initialize(): bind() failed\n");
		shutdown(s,SD_BOTH);
		closesocket(s);
		s=INVALID_SOCKET;
		bValid=false;
		bDisconnected=true;
		return false;
	}
	// k, socket set up now

	Server.Port=htons(serverport);
	Server.IP=inet_addr(serveraddress);
	if (Server.IP == 0xffffffff)				// if not, we resolve hostname
	{
		hostent *lphost;
		lphost = gethostbyname(serveraddress);
		if (!lphost)
		{
			EQIM->Debug.Log("CEQIMSockets::Initialize() gethostbyname() failed\n");
			return false;
		}
		Server.IP = ((in_addr *)lphost->h_addr)->s_addr;
	}


	Server.sa_family=2;

	bValid=true;
	bDisconnected=false;
	EQIM->Debug.Log("CEQIMSockets::Initialize(): Initialized\n");
	return true;
}




