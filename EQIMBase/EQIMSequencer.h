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

struct SeqNode
{
	_Data Data;
	SeqNode *pNext;
	SeqNode *pLast;
};

class CSequence
{
public:
	CSequence()
	{
		head=0;
		tail=0;
	}
	~CSequence()
	{
		Clear();
	}

	void Add(const _Data &Data);
	void Remove(unsigned short Seq);
	void Clear();

	SeqNode *head;
	SeqNode *tail;
//	CCriticalSection S;
	CSemaphore S;

};

class CEQIMSequencer
{
public:
	CEQIMSequencer(void *pEQIM);
	~CEQIMSequencer(void);

	void Reset();
	unsigned short GetNextSeq();

	void GotAck(unsigned short Ack);
	bool GotSeq(unsigned short Seq);

	void GotError(unsigned short Ack);

	CSequence Outgoing;

private:
	void *m_EQIM;
	unsigned short NextSeq;
	unsigned long NextIncoming;

//	CCriticalSection S;
	CSemaphore S;

};
