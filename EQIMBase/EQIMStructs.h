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
#ifndef __EQIM_STRUCTS_H__
#define __EQIM_STRUCTS_H__

enum EQIMServer
{
	ES_NONE,
	ES_LOGIN,
	ES_CHAT
};

enum ChannelMemberStatus
{
	CM_GONE,
	CM_NORMAL,
	CM_VOICE,
	CM_OP,
	CM_OWNER
};

struct _Data
{
	unsigned short Seq;
	int size;
	char buffer[512];
	bool Processed;
};

struct EQIMChannel
{
	char FullName[80];
	unsigned long Number;
	unsigned long LastUpdateTry;
	unsigned long LastUpdate;
	bool Moderated;
};

struct EQIMChannelMember
{
	char FullName[80];
	ChannelMemberStatus Status;
	bool AutoOp;
};

struct EQIMBuddy
{
	char FullName[80];
	unsigned char Status;
};

/* SOCKADDR */
struct Addr
{
	unsigned short sa_family;
	/* sa_data */
	unsigned short Port;
	unsigned long IP; // inet_addr
	unsigned long unusedA;
	unsigned long unusedB;
};


// OUT: Opcode 0x00 0x01
// Initialize Session
// Size: 12 bytes
struct out_session
{
	unsigned long UnknownA;
	unsigned long Session;
	unsigned short UnknownB;
	unsigned short MaxLength;
};


// IN: Opcode 0x00 0x02
// Initialize Session response
// Size: 15 bytes
struct in_session
{
	unsigned long Session; 
	unsigned long Key;
	unsigned short UnknownA;
	unsigned short UnknownB;
	unsigned char UnknownC;
	unsigned short MaxLength;
};

// OUT: Opcode 0x00 0x05
// Close session
// Size: 4 bytes
struct out_close
{
	unsigned long Session;
};

// IN/OUT: Opcode 0x00 0x09
// Ack request
// Size: 2 bytes
struct inout_ackreq
{
	unsigned short Seq;
};

// IN/OUT: Opcode 0x00 0x15
// Ack response
// Size: 2 bytes
struct inout_ackrsp
{
	unsigned short Seq;
};


struct _Validated
{
	char Name[64];
	char IPAddr[64];
	char Port[6];
	char Code[9];
};

	static struct EQServer {
		char LongName[64];
		char ShortName[32];
	} servers[] = {
	{"Antonius Bayle","antonius"},
	{"Ayonae Ro","ayonae"},
	{"Bertoxxulous","bertox"},
	{"Brell Serillis","brell"},
	{"Bristlebane","bristle"},
	{"Cazic-Thule","cazic"},
	{"Drinal","drinal"},
	{"Druzzil Ro","druzzil"},
	{"E`ci","eci"},
	{"Erollisi Marr","erollisi"},
	{"Fennin Ro","fenninro"},
	{"Firiona Vie","firiona"},
	{"Innoruuk","innoruuk"},
	{"Kael Drakkal","kael"},
	{"Kane Bayle","kane"},
	{"Karana","karana"},
	{"Lanys T`vyl","lanys"},
	{"Luclin","luclin"},
	{"Maelin Starpyre","maelin"},
	{"Mithaniel Marr","mithaniel"},
	{"Morden Rasp","morden"},
	{"Morell-Thule","morell"},
	{"The Nameless","nameless"},
	{"Povar","povar"},
	{"Prexus","prexus"},
	{"Quellious","quellious"},
	{"Rallos Zek","rallos"},
	{"The Rathe","rathe"},
	{"Rodcet Nife","rodcet"},
	{"Saryrn","saryrn"},
	{"Sebilis","sebilis"},
	{"The Seventh Hammer","seventh"},
	{"Solusek Ro","solusek"},
	{"Stormhammer","stormhammer"},
	{"Stromm","stromm"},
	{"Sullon Zek","sullon"},
	{"Tallon Zek","tallon"},
	{"Tarew Marr","marr"},
	{"Terris-Thule","terris"},
	{"Tholuxe Paells","tholuxe"},
	{"Torvonnilous","torvon"},
	{"The Tribunal","tribunal"},
	{"Tunare","tunare"},
	{"Vallon Zek","vallon"},
	{"Vazaelle","vazaelle"},
	{"Veeshan","veeshan"},
	{"Venril Sathir","venril"},
	{"Xegony","xegony"},
	{"Xev","xev"},
	{"Zebuxoruk","zebuxoruk"},
	{"Serverwide","serverwide"},
	{"Test Server","test"},
	{"",""},
	};
#endif
