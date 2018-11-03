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

#include "EQIM.h"
#include "EQIMInterface.h"

#define Interface ((CEQIMInterface*)(m_Interface))

//#define DebugTry(x) eqim->Debug.Logf("Trying %s\n",#x);x;eqim->Debug.Logf("%s complete\n",#x)
#define DebugTry(x) x

THREAD WINAPI ChatThreadFunction( LPVOID pParam )
{
	CThread *pThread=(CThread*)pParam;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	CEQIM* eqim=(CEQIM*)pThread->Info;
	CEQIMInterface *m_Interface=(CEQIMInterface*)eqim->m_Interface;
	eqim->Outgoing.Clear();
//	eqim->ChatReady=false;
//	eqim->ChatThreading=true;
	eqim->Encoder.EncodeKey=0;
	eqim->Encoder.DecodeKey=0;
	eqim->Debug.Log("ChatThreadFunction() entry\n");
	time_t LastRecv=time(0);
	if (!eqim->Socket.Initialize(eqim->LocalPort,&eqim->Validated.IPAddr[0],atoi(&eqim->Validated.Port[0])))
	{
		eqim->Debug.Log("ChatThreadFunction():: Socket initialization failed\n");
//		eqim->ChatThreading=false;
//		eqim->ChatReady=true;
		pThread->bThreading=false;
		pThread->ThreadReady=true;
		return (THREAD)666;
	}
	eqim->ServerType=ES_CHAT;
	char buf[2048];
	int bufsize=0;
	unsigned short CRC=0;

	_Data Out;
	time_t LastPulse=0;

	pThread->ThreadReady=true;
	Interface->ChatReady();

	unsigned long incoming=0;
	while(pThread->CloseThread==false && eqim->Socket.bDisconnected==false)
	{
		// check for incoming data
		incoming=eqim->Socket.IsData();
		if (incoming>0)
		{
//			eqim->Debug.Log("Incoming Data...\n");
			LastRecv=time(0);
			// we get signal
			bufsize=eqim->Socket.RecvFrom(&buf[0],2048);
			// process incoming buffer
			if (bufsize>0)
			{
				if (bufsize>2047)
				{
					eqim->Debug.Logf("Warning: bufsize %d in ChatThreadFunction\n");
				}
				bufsize=eqim->Processor.PreProcessIncomingData((unsigned char*)&buf[0],bufsize);
				DebugTry(eqim->Processor.ProcessIncomingData((unsigned char*)&buf[0],bufsize));
			}
			else
			{
				// socket error
				eqim->Debug.Log("ChatThreadFunction() socket error in recv\n");
				break;
			}
		}
		
		// inactivity timeout
		time_t now=time(0);
		if (difftime(now,LastRecv)>300)
		{
			eqim->Debug.Log("Inactivity timeout\n");
			eqim->GotDisconnect(true);
		}

		// check for outgoing data, make an encoded packet to send out if necessary

		if (eqim->CreateOutgoingPacket(Out))
		{
			// encode
			eqim->Debug.LogBuffer(Out.buffer,Out.size,"Sending outgoing packet");
			eqim->Encoder.Encode((unsigned char*)&Out.buffer[2],Out.size-2);
			CRC=eqim->Socket.CRC16((unsigned char *)&Out.buffer[0],Out.size);
			*(unsigned short*)&Out.buffer[Out.size]=htons(CRC);
			Out.size+=2;

			if (eqim->Socket.SendTo(&Out.buffer[0],Out.size)==SOCKET_ERROR)
			{
				// socket error
				eqim->Debug.Log("ChatThreadFunction() socket error in send\n");
				// packet will be resent when requested.
				break;
			}
		}

		if (LastPulse-now>=2)
		{
			LastPulse=now;
			Interface->Pulse();
		}

		Sleep(10);
	}
	eqim->Debug.Log("ChatThreadFunction() loop exit\n");

	eqim->CloseSession();
	eqim->Socket.ShutDown();
	pThread->bThreading=false;
	eqim->Debug.Log("ChatThreadFunction() exit\n");
	return (THREAD)667;
}


#pragma warning( disable :4355)
CEQIM::CEQIM(void):Socket(this),Sequencer(this),Encoder(this),Processor(this),Login(this),Channels(this),Buddies(this)
{
	sServer[0]=0;
	sPassword[0]=0;
	sStationName[0]=0;
	sCharacter[0]=0;
	m_Interface=0;
	SessionNumber=0;
	ServerType=ES_NONE;
	Disconnected=false;
	srand((unsigned)time(0));
	LocalPort=((rand()+rand())%62000)+2000;
}

CEQIM::~CEQIM(void)
{
	CloseSession();
	ChatThread.EndThread();
}




bool CEQIM::InitializeSession(unsigned long number)
{
	Debug.Logf("CEQIM::InitializeSession(): %d\n",number);

    SessionNumber=number;

	// login, always same
	//  op  |           |  number   |      maxlen
	// 00 01 00 00-00 02 00 29-48 23 00 00-02 00
	// validation, different #
	//  op  |           |  number   |      maxlen
	// 00 01 00 00-00 02 18 BE-67 84 00 00-02 00

	char buf[24];
	buf[0]=0;
	buf[1]=1;
	out_session *out=(out_session*)&buf[2];
	out->UnknownA=htonl(2);
	out->UnknownB=0;
	out->Session=htonl(number);
	out->MaxLength=htons(512);
	Socket.SendTo(&buf[0],sizeof(out_session)+2);

	return true;
}

bool CEQIM::CloseSession()
{
	if (SessionNumber==0)
		return false;
	Debug.Log("CEQIM::CloseSession()\n");
	EndSession();

	
	Sleep(100);
	SessionNumber=0;
	Socket.ShutDown();
	if (ChatThread.bThreading)
	{
		ChatThread.CloseThread=true;
	}
	ServerType=ES_NONE;
	return true;
}

void CEQIM::EndSession()
{
	if (SessionNumber==0)
		return;
	Debug.Log("CEQIM::EndSession()\n");
	//  op  | number
	// 00 05 00 29-48 23
	char buf[24];
	buf[0]=0;
	buf[1]=5;
	out_close *out=(out_close*)&buf[2];
	out->Session=htonl(SessionNumber);
	// this needs to be encoded+crc if connected to chat server!
	if (ServerType==ES_CHAT)
	{
		unsigned char size=sizeof(out_close);
		Encoder.Encode((unsigned char*)&buf[2],size);
		size+=2;
		unsigned short CRC=Socket.CRC16((unsigned char *)&buf[0],size);
		*(unsigned short*)&buf[size]=htons(CRC);
		size+=2;
		Socket.SendTo(&buf[0],size);
	}
	else
		Socket.SendTo(&buf[0],sizeof(out_close)+2);
	

	// send disconnect opcode?
//	buf[1]=0x1D;
//	Socket.SendTo(&buf[0],2);
	return;
}

// BeginChat
// This function takes the validated info, completes the login process
// and begins the chatting thread
bool CEQIM::BeginChat()
{
	if (ChatThread.bThreading)
		return false;
	ServerType=ES_NONE;
	Debug.Log("Beginning chat session\n");
	Sequencer.Reset();
	ChatThread.BeginThread(&ChatThreadFunction,this);

	return true;
}

void CEQIM::GotDisconnect(bool ServerAction)
{
	Debug.Log("Received disconnect signal\n");
	Interface->GotDisconnect(ServerAction);
	ServerType=ES_NONE;
	Buddies.Clear();
	Channels.UpdateChannels("");
}

bool CEQIM::CreateOutgoingPacket(_Data &Out)
{
	if (Outgoing.Empty())
		return false;
	ZeroMemory(&Out,sizeof(_Data));

	_Data Data;
	_Data Temp;

	Data=Outgoing.Pop();
	if (!Data.Processed)
	{
		// insert ack req
		Data.Processed=true;
		memmove(&Data.buffer[4],&Data.buffer[0],512-4);
		Data.size+=4;
		Data.buffer[0]=0;
		Data.buffer[1]=9;
		*(unsigned short*)&Data.buffer[2]=htons(Data.Seq=Sequencer.GetNextSeq());
	}
	else
	{
		Out=Data;
		return true;
	}
	Out=Data;

	if ( Data.size<255 && !Outgoing.Empty())
	{
		Temp=Outgoing.Peek();
		if (Temp.size>254)
		{
			Sequencer.Outgoing.Add(Out);
			return true;
		}
	}
	else
	{
		Sequencer.Outgoing.Add(Out);
		return true;
	}

	// multiple commands
	memmove(&Out.buffer[3],&Out.buffer[0],512-3);
	Out.size+=3;
	Out.buffer[0]=0;
	Out.buffer[1]=3;
	unsigned char size=Out.size;
	Out.buffer[2]=size;
	int b=3+Out.size;

	while(Temp.size<=254 && Temp.size+b<370)
	{
		Data=Outgoing.Pop();
		size=Data.size;
		Out.buffer[b++]=size;
		memcpy(&Out.buffer[b],&Data.buffer[0],size);
		b+=Data.size;

		if (!Outgoing.Empty())
		{
			Temp=Outgoing.Peek();
		}
		else
		{
			Temp.size=2048;
			break;
		}
	}
	Out.size=b;

	Sequencer.Outgoing.Add(Out);
	return true;
}

void CEQIM::GotSessionInfo(in_session* session)
{

	Encoder.DecodeKey=Encoder.EncodeKey=htonl(session->Key);
}


bool CEQIM::SendCommand(const char *str)
{
	if (!str || str[0]!=';' || strlen(str)>300)
		return false; // invalid
	_Data NewData;
	NewData.Processed=false;
	NewData.buffer[0]=0x02;
	strcpy(&NewData.buffer[1],(char*)str);
	NewData.size=(int)strlen(str)+/*null terminator*/1+1/*opcode 0x02*/;
	Outgoing.Push(NewData);
	return true;
}

bool CEQIM::SendCommandf(const char *format,...)
{
	if (!format)
		return false;
    CHAR szOutput[20480] = {0};
    va_list vaList;
    va_start( vaList, format );
    vsprintf(szOutput,format, vaList);
	if (szOutput[0]!=';' || strlen(szOutput)>300)
		return false; // invalid
	_Data NewData;
	NewData.Processed=false;
	NewData.buffer[0]=0x02;
	strcpy(&NewData.buffer[1],szOutput);
	NewData.size=(int)strlen(szOutput)+/*null terminator*/1+1/*opcode 0x02*/;
	Outgoing.Push(NewData);
	return true;
}

bool CEQIM::SendBuffer(unsigned char *str, int size)
{
	if (!str || !size || size>480)
		return false;
	_Data NewData;
	NewData.Processed=false;
	memcpy(&NewData.buffer[0],&str[0],size);
	NewData.size=size;
	Outgoing.Push(NewData);
	return true;
}

void CEQIM::Validate()
{
	char out[512];
	int outsize=0;
	out[outsize++]=1;
	out[outsize++]=0;
	strcpy(&out[outsize],sServer);
	outsize+=strlen(sServer);
	out[outsize++]=0x2E;
	strcpy(&out[outsize],sCharacter);
	outsize+=strlen(sCharacter);
	out[outsize++]=0;
	strcpy(&out[outsize],&Validated.Code[0]);
	outsize+=(int)strlen(&Validated.Code[0]);
	outsize++;
	SendBuffer((unsigned char*)&out[0],outsize);
}

void CEQIM::KeepAlive()
{
	Debug.Log("Sending keep alive\n");
	char out[5];
	int outsize=0;
	out[outsize++]=0;
	out[outsize++]=6;
	SendBuffer((unsigned char*)&out[0],outsize);
}



