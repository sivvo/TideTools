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
#include "EQIMSequencer.h"
#include "EQIM.h"

#define EQIM ((CEQIM*)m_EQIM)

//#define DEBUG_SEQUENCER 1

CEQIMSequencer::CEQIMSequencer(void *pEQIM)
{
	NextSeq=0;
	NextIncoming=0;
	m_EQIM=pEQIM;
}

CEQIMSequencer::~CEQIMSequencer(void)
{
}

unsigned short CEQIMSequencer::GetNextSeq()
{
	CLock L(&S,true);
	unsigned short ret = NextSeq;
	NextSeq++;
	return ret;
}


void CEQIMSequencer::Reset()
{
	CLock L(&S,true);
	NextSeq=0;
	NextIncoming=0;
	Outgoing.Clear();
}

void CEQIMSequencer::GotError(unsigned short Ack)
{
	CLock L(&S,true);
	// re-send packets up to and including Ack
	unsigned long nSent=0;
//	char out[256];
	CLock Z(&Outgoing.S,true);
	SeqNode *node=Outgoing.head;
//	sprintf(out,"GotError(%d) head Seq is %d\n",Ack,node->Data.Seq);
//	EQIM->Debug.Log(out);
	while(node && node->Data.Seq<=Ack)
	{
		{
			nSent++;
			EQIM->Outgoing.Push(node->Data);
		}
		node=node->pNext;
	}
//	sprintf(out,"GotError() %d packets re-sent\n",nSent);
//	EQIM->Debug.Log(out);
}

void CEQIMSequencer::GotAck(unsigned short Ack)
{
//#ifdef DEBUG_SEQUENCER
//	EQIM->Debug.Logf("CEQIMSequencer::GotAck(%d)\n",Ack);
//#endif
	CLock L(&S,true);
	Outgoing.Remove(Ack);
	if (Ack>NextSeq)
	{
		NextSeq=Ack+1;
		// error
	}
}

bool CEQIMSequencer::GotSeq(unsigned short Seq)
{
//#ifdef DEBUG_SEQUENCER
//	EQIM->Debug.Logf("CEQIMSequencer::GotSeq(%d)\n",Seq);
//	static bool PacketLost=false;
//	if (!PacketLost && Seq==15)
//	{
//		PacketLost=true;
//		return false;
//	}
//#endif
	// determine if we send error or success
	if (Seq==NextIncoming)
	{	// success
		NextIncoming++;
		_Data NewData;
		NewData.buffer[0]=0;
		NewData.buffer[1]=0x15;
		*(unsigned short*)&NewData.buffer[2]=htons(Seq);
//		EQIM->Debug.Logf("Sending ack (%d)\n",Seq);
		NewData.size=4;
		NewData.Seq=65535;
		EQIM->Outgoing.Push(NewData);
		return true;
	}
	else
	{
		// incorrect!
		if (Seq>NextIncoming)
		{
			/*
			if (Seq>NextIncoming+100)
			{
				// problem
				EQIM->Debug.Log("Packet sequencer problem, ending session\n");
				EQIM->EndSession();
				return false;
			}
			/**/
			// send error packet
//			EQIM->Debug.Logf("Unreceived packets, sending re-send code (%d)\n",NextIncoming-1);
			_Data NewData;
			NewData.buffer[0]=0;
			NewData.buffer[1]=0x11;
			*(unsigned short*)&NewData.buffer[2]=htons((unsigned short)NextIncoming-1);
			NewData.size=4;
			NewData.Seq=65535;
			NewData.Processed=true;
			EQIM->Outgoing.Push(NewData);
		}
		else
		{
			// if it's previous to NextIncoming, then we already sent a success
			// packet to this data, and we can ignore it.
		}
		return false;
	}
}

void CSequence::Add(const _Data &Data)
{
	if (Data.Seq==65535)
		return;
	CLock L(&S,true);
	SeqNode *node = new SeqNode;
	node->Data=Data;
	node->pNext=0;
	node->pLast=tail;
	if (tail)
		tail->pNext=node;
	else
		head=node;
	tail=node;
}

void CSequence::Remove(unsigned short Seq)
{
	CLock L(&S,true);
	SeqNode *node = head;
	while(node)
	{
		if (node->Data.Seq<=Seq)
		{
			SeqNode *next=node->pNext;
			if (node->pNext)
				node->pNext->pLast=node->pLast;
			else
				tail=node->pLast;
			if (node->pLast)
				node->pLast->pNext=node->pNext;
			else
				head=node->pNext;
			delete node;
			node=next;
			continue;
		}
		else
		{
			return;
		}
		node=node->pNext;
	}
}

void CSequence::Clear()
{
	CLock L(&S,true);
	while(head)
	{
		SeqNode *pNext=head->pNext;
		delete head;
		head=pNext;
	}
	head=0;
	tail=0;
}
