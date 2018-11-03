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
#include "EQIMEncoder.h"
#include <malloc.h>
#include <memory.h>
#include "EQIM.h"
#include "libdes/des.h"
#include "libdes/spr.h"


#define EQIM ((CEQIM*)m_EQIM)

//#define DEBUG_ENCODER 1

CEQIMEncoder::CEQIMEncoder(void *pEQIM)
{
	m_EQIM=pEQIM;
}

CEQIMEncoder::~CEQIMEncoder(void)
{
}

void CEQIMEncoder::Encode(unsigned char *buffer, int size) // in-place encoding
{
//        EQIM->Debug.LogBuffer((char*)buffer,size,"Pre-Encode");
	int Key=EncodeKey;
//-----------------------------
	char *test=(char*)malloc(size);
        int i;
	for ( i = 0 ; i+4 <= size ; i+=4)
	{
		int pt = (*(int*)&buffer[i])^(Key);
		Key = pt;
		*(int*)&test[i]=pt;
	}
	unsigned char KC=Key&0xFF;
	for ( i ; i < size ; i++)
	{
		test[i]=buffer[i]^KC;
	}
	memcpy(&buffer[0],&test[0],size);	
	free(test);
#ifdef DEBUG_ENCODER
	EQIM->Debug.LogBuffer(buffer,size,"Post-Encode");
#endif
}

void CEQIMEncoder::Decode(unsigned char *buffer, int size) // in-place decoding
{
#ifdef DEBUG_ENCODER
	CString sTemp;
	sTemp.Format("Pre-Decode, Key 0x%08X",DecodeKey);
	EQIM->Debug.LogBuffer(buffer,size,sTemp);
#endif
	int Key=DecodeKey;
	char *test=(char*)malloc(size);
        int i;
	for (i = 0 ; i+4 <= size ; i+=4)
	{
		int pt = (*(int*)&buffer[i])^(Key);
		Key = (*(int*)&buffer[i]);
		*(int*)&test[i]=pt;
	}
	unsigned char KC=Key&0xFF;
	for ( i ; i < size ; i++)
	{
		test[i]=buffer[i]^KC;
	}
	memcpy(&buffer[0],&test[0],size);	
	free(test);
#ifdef DEBUG_ENCODER
	EQIM->Debug.LogBuffer((char*)buffer,size,"Post-Decode");
#endif
}

int CEQIMEncoder::EncryptPassword(const char *buffer, char *outbuffer)
{
	des_cblock Key;
	des_key_schedule Schedule;
	des_string_to_key("$?<:IXaaElHcZ8eF",&Key);
	des_cblock* Ivec=&Key;
	set_key(Ivec,Schedule);
	char xbuffer[256];
	memset(xbuffer,0,256);
	int newsize=((int)strlen(buffer)+7)&0xFFF8;
	strcpy(xbuffer,buffer);
	des_cbc_encrypt((des_cblock *)&xbuffer[0],(des_cblock *)&outbuffer[0],newsize,Schedule,Ivec,1);
	outbuffer[newsize]=0;
	return (int)strlen(&outbuffer[0]);

}

