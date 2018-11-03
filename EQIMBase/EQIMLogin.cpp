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
#include "EQIMLogin.h"
#include "EQIMInterface.h"
#include "EQIM.h"

#define EQIM ((CEQIM*)m_EQIM)

/*
Out: 00 01   <InitializeSession>
In: 00 02    <SessionInfo>

Out:          Login User Pass
In:           LoginRsp

Out:          WorldQry   -- optional
In:           WorldRsp   ^^^^^^^^^^^

Out:          Validate
In:           ValidateRsp

Out: 00 05   <CloseSession>
*/



THREAD WINAPI LoginThreadFunction( LPVOID pParam )
{
	CThread *pThread=(CThread*)pParam;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	CEQIM* eqim=(CEQIM*)pThread->Info;
	CEQIMInterface *Interface=(CEQIMInterface*)(eqim->m_Interface);
	eqim->Outgoing.Clear();
//	eqim->Login.LoginReady=false;
//	eqim->Login.LoginThreading=true;
	eqim->Encoder.EncodeKey=0;
	eqim->Encoder.DecodeKey=0;
	eqim->Debug.Log("LoginThreadFunction() entry\n");

	if (!eqim->Socket.Initialize(eqim->LocalPort,"sdlaunchpad1.station.sony.com",4003))
	{
		eqim->Debug.Log("LoginThreadFunction():: Socket initialization failed\n");
//		eqim->Login.LoginThreading=false;
//		eqim->Login.LoginReady=true;
		pThread->bThreading=false;
		pThread->ThreadReady=true;
		return (THREAD)666;
	}
	eqim->ServerType=ES_LOGIN;
	char buf[512];
	int bufsize=0;
	char out[512];
	int outsize=0;

	//eqim->Login.LoginReady=true;
	pThread->ThreadReady=true;
	Interface->LoginReady();

	unsigned long incoming=0;
//	while(eqim->Login.KillLoginThread==false && eqim->Socket.bDisconnected==false)
	while(pThread->CloseThread==false && eqim->Socket.bDisconnected==false)
	{
		// check for incoming data
		incoming=eqim->Socket.IsData();
		if (incoming>0)
		{
			// we get signal
			bufsize=eqim->Socket.RecvFrom(&buf[0],512);
			// process incoming buffer
			if (bufsize>0)
			{
//				eqim->Debug.LogBuffer(&buf[0],bufsize,"Incoming");
				eqim->Login.ProcessIncomingData((unsigned char*)&buf[0],bufsize);
			}
			else
			{
				// socket error
				eqim->Debug.Log("LoginThreadFunction() socket error in recv\n");
				break;
			}
		}
		
		// check for outgoing data, make an encoded packet to send out if necessary
		outsize=eqim->Login.CreateOutgoingPacket((unsigned char*)&out[0]);
		unsigned short CRC=0;
		if (outsize>=1)
		{
			// Login packets DO NOT GET ENCODED, OR CRC16
				eqim->Debug.LogBuffer(&out[0],outsize,"Outgoing Login");
			
			if (eqim->Socket.SendTo(&out[0],outsize)==SOCKET_ERROR)
			{
				// socket error
				eqim->Debug.Log("LoginThreadFunction() socket error in send\n");
				break;
			}
		}
		Sleep(10);
	}

	eqim->CloseSession();
	eqim->Socket.ShutDown();
	pThread->bThreading=false;
//	eqim->Login.LoginThreading=false;
	eqim->Debug.Log("LoginThreadFunction() exit\n");
	return (THREAD)667;
}

#define Interface ((CEQIMInterface*)(EQIM->m_Interface))

CEQIMLogin::CEQIMLogin(void *pEQIM)
{
	m_EQIM=pEQIM;
	LoginState=0;
//	KillLoginThread=false;
//	LoginThreading=false;
//	LoginReady=false;
}

CEQIMLogin::~CEQIMLogin(void)
{
	LoginThread.EndThread();
	/*
	if (LoginThreading)
	{
		KillLoginThread=true;
		while(LoginThreading)
		{
			Sleep(100);
		}
	}
	/**/
}

void CEQIMLogin::ProcessIncomingData(unsigned char *buf, int size)
{
	// ok first we have to check the opcode and determine how to break up this info
	if (size<=1 || buf==0)
		return;

	if (buf[0]!=0)
	{
			// invalid, log it
		if (buf[0]>=32)
		{
			ProcessLoginResponse((char*)&buf[0],size);
		}
		else
			EQIM->Debug.LogBuffer((char *)&buf[0],size,"Received invalid or unexpected data");
		return;
	}

	// Now decide the fate of the data
	switch(buf[1])
	{
	case 0x02:
		// session initialization
		EQIM->GotSessionInfo((in_session*)&buf[2]);
		Interface->LoginConnected();
		break;
	case 0x03:
		// split message
		{
			int i = 2;
			while(i < size)
			{
				unsigned char c=buf[i]; // get the length of this message
				ProcessIncomingData(&buf[i+1],c); // re process it, dont decode
				i+=c+1;
			}
		}
		break;
	case 0x05:
		// session closing
		// re-send initialization
		//EQIM->GotDisconnect();
		break;
	case 0x06:
		// keep-alive
		break;
	case 0x09:
		// ack request
		if (EQIM->Sequencer.GotSeq(htons(*(unsigned short*)&buf[2])))
		{
			ProcessIncomingData(&buf[4],size-4);
		}
		break;
	case 0x11:
		ProcessIncomingData(&buf[4],size-4);
		EQIM->Sequencer.GotError(htons(*(unsigned short*)&buf[2]));
		break;
	case 0x15:
		// ack response
		// yippie they got it, lets have a party. OR.. continue with our lives.
		// 0 1 2 3
		ProcessIncomingData(&buf[4],size-4);
		EQIM->Sequencer.GotAck(htons(*(unsigned short*)&buf[2]));
		break;
	case 0x19:
		// split message
		{
			int i = 2;
			while(i < size)
			{
				unsigned char c=buf[i]; // get the length of this message
				ProcessIncomingData(&buf[i+1],c); // re process it, dont decode
				i+=c+1;
			}
		}
		break;
	case 0x1D:
		// disconnect
		{
			EQIM->GotDisconnect();
		}
	default:
		// invalid, log it
		EQIM->Debug.LogBuffer((char *)&buf[0],size,"Received invalid or unexpected data");
		break;
	}
}

void CEQIMLogin::ProcessLoginResponse(char *buf, int size)
{
	                  //0123456789
	if (strstr(&buf[0],"LoginRsp")==&buf[0])
	{
		GotLoginRsp(&buf[9]);
	}
	else
	if (strstr(&buf[0],"WorldRsp")==&buf[0])
	{
		GotWorldRsp(&buf[9]);
	}
	else                  //0123456789012
	if (strstr(&buf[0],"ValidateRsp")==&buf[0])
	{
		GotValidateRsp(&buf[12]);
	}
	else
	{
		Interface->GotUnknownRsp(buf);
	}
}

void CEQIMLogin::GotLoginRsp(char *buf)
{
	if (!strcmp(&buf[0],"SUCCESS"))
	{
		// logged in
		Interface->GotLoginRsp(true);
	}
	else
	{
		// failure
		Interface->GotLoginRsp(false);
	}
}

void CEQIMLogin::GotWorldRsp(char *buf)
{
	// character list
	Interface->GotWorldRsp(buf);
}

void CEQIMLogin::GotValidateRsp(char *buf)
{
	int n=0;
	char *token=strtok(buf," ");
	while(token)
	{
		switch(n)
		{
		case 0:
			strcpy(&EQIM->Validated.Name[0],&token[0]);
			break;
		case 1:
			strcpy(&EQIM->Validated.IPAddr[0],&token[0]);
			break;
		case 2:
			strcpy(&EQIM->Validated.Port[0],&token[0]);
			break;
		case 3:
			strcpy(&EQIM->Validated.Code[0],&token[0]);
			break;
		default:
			break;
		}
		n++;
		token=strtok(NULL," ");
	}
	if (n==4) 
	{
		char Temp[256];
		sprintf(Temp,"%s.%s",EQIM->sServer,EQIM->sCharacter);
		if (!stricmp(Temp,&EQIM->Validated.Name[0]))
		{
			// Validated successfully.
			Interface->GotValidateRsp(true);
		}
		else
		{
			// Wrong character...
		}
	}
	else
	{
		// Invalid ValidateRsp
		Interface->GotValidateRsp(false);
	}
}

int CEQIMLogin::CreateOutgoingPacket(unsigned char *buf)
{
	if (EQIM->Outgoing.Empty())
		return 0;
	_Data Data;
	Data=EQIM->Outgoing.Pop();
	// insert ack request
	if (!Data.Processed)
	{
		Data.Processed=true;
		memmove(&Data.buffer[4],&Data.buffer[0],512-4);
		Data.size+=4;
		Data.buffer[0]=0;
		Data.buffer[1]=9;
		*(unsigned short*)&Data.buffer[2]=htons(Data.Seq=EQIM->Sequencer.GetNextSeq());
		EQIM->Sequencer.Outgoing.Add(Data);
	}
	memcpy(&buf[0],&Data.buffer[0],Data.size);
	return Data.size;
}

void CEQIMLogin::TryLogin(const char *name, const char *pass)
{
	char out[256];
	char pwd[256];
	memset(&pwd[0],0,256);
	EQIM->Encoder.EncryptPassword(&pass[0],&pwd[0]);
	int len=sprintf(&out[0],"Login %s %s",&name[0],&pwd[0])+1;
	EQIM->SendBuffer((unsigned char *)&out[0],len);
}

void CEQIMLogin::TryLoginPreEncrypted(const char *name, const char *pass)
{
	char out[256];
	int len=sprintf(&out[0],"Login %s %s",&name[0],&pass[0])+1;
	EQIM->SendBuffer((unsigned char *)&out[0],len);
}

void CEQIMLogin::ListChars(const char *servername)
{
	char out[256];
	int len;
	if (!stricmp(servername,"fenninro"))
		len=sprintf(&out[0],"WorldQry %s","fennin")+1;
	else if (!stricmp(servername,"marr"))
		len=sprintf(&out[0],"WorldQry %s","tarew")+1;
	else
		len=sprintf(&out[0],"WorldQry %s",servername)+1;
	EQIM->SendBuffer((unsigned char *)&out[0],len);
}

void CEQIMLogin::SendCommandf(const char *format,...)
{
	char szOutput[2048];
    va_list vaList;
    va_start( vaList, format );
    vsprintf(szOutput,format, vaList);
	int len=(int)strlen(szOutput)+1;
	if (!len || len>300)
		return; // invalid
	
	EQIM->SendBuffer((unsigned char *)&szOutput[0],len);
}

void CEQIMLogin::SendCommandfNo0(const char *format,...)
{
	char szOutput[2048];
    va_list vaList;
    va_start( vaList, format );
    vsprintf(szOutput,format, vaList);
	int len=(int)strlen(szOutput);
	if (!len || len>300)
		return; // invalid
	
	EQIM->SendBuffer((unsigned char *)&szOutput[0],len);
}

void CEQIMLogin::TryValidate(const char *servername, const char *name)
{
	char out[256];
	int len;
	if (!stricmp(servername,"fenninro"))
		len=sprintf(&out[0],"Validate %s %s","fennin",name)+1;
	else if (!stricmp(servername,"marr"))
		len=sprintf(&out[0],"Validate %s %s","tarew",name)+1;
	else
		len=sprintf(&out[0],"Validate %s %s",servername,name)+1;
	EQIM->SendBuffer((unsigned char *)&out[0],len);
}

void CEQIMLogin::BeginLogin()
{
	if (LoginThread.bThreading || EQIM->ChatThread.bThreading)
		return;
	EQIM->ServerType=ES_NONE;
	EQIM->Debug.Log("Beginning login process\n");
	EQIM->CloseSession();
	EQIM->Sequencer.Reset();

	LoginThread.BeginThread(&LoginThreadFunction,m_EQIM);
//	KillLoginThread=false;
//	DWORD ThreadID;
//	CreateThread(NULL,0,&LoginThreadFunction,m_EQIM,0,&ThreadID);
}

