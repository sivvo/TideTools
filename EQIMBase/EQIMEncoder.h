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

class CEQIMEncoder
{
public:
	CEQIMEncoder(void *pEQIM);
	~CEQIMEncoder(void);

	unsigned long EncodeKey;
	unsigned long DecodeKey;

	void Encode(unsigned char *buffer, int size); // in-place encoding
	void Decode(unsigned char *buffer, int size); // in-place decoding

	int EncryptPassword(const char *buffer, char *outbuffer);

	void *m_EQIM;
};
