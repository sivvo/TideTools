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

/*
[20:13:57] *** Chat System Command List:
[20:13:57] ***    ;join <channel-list>
[20:13:57] ***    ;leave <channel>
[20:13:57] ***    ;<1..10> <message>
[20:13:57] ***    ;#<channel-name> <message>
[20:13:57] ***    ;leaveall
[20:13:57] ***    ;set <channel-list>
[20:13:57] ***    ;list [channel]
[20:13:57] ***    ;announce [on | off]
[20:13:57] ***    ;ignore [on | off]
[20:13:57] ***    ;tell  <message>
[20:13:57] ***    ;oplist [channel]
[20:13:57] ***    ;invisible [on | off]
[20:13:57] ***    ;afk [on | off]
[20:13:57] ***    ;buddy <[-]player-name>[,...]
[20:13:57] ***    ;namespace
[20:13:57] *** Channel Moderator Command List:
[20:13:57] ***    ;invite  [channel]
[20:13:57] ***    ;kick  [channel]
[20:13:57] ***    ;moderate [channel]
[20:13:57] ***    ;local [channel]
[20:13:57] ***    ;voice  [channel]
[20:13:57] ***    ;grant  [channel]
[20:13:57] ***    ;password password [channel]
[20:13:57] *** Channel Owner Command List:
[20:13:57] ***    ;opadd  [channel]
[20:13:57] ***    ;opremove  [channel]
[20:13:57] ***    ;setowner  [channel]
*/

#define IM_UNKNOWN						0

// buddy list
#define IM_BUDDYLISTMODIFIED			1

// misc
#define IM_NOPLAYER						2
#define IM_INVALIDCOMMAND				3

// channel operator stuff
#define IM_CHANNELNOPERMISSION			4
#define IM_CHANNELNOTOWNER				5
#define IM_CHANNELNOPLAYER				6
#define IM_CHANNELALREADYPLAYER			7
#define IM_CHANNELPLAYERKICKED			8
#define IM_CHANNELPLAYERVOICED			9
#define IM_CHANNELPASSWORDCHANGED		10
#define IM_CHANNELPLAYERINVITED			11
#define IM_CHANNELMEOPPED				12
#define IM_CHANNELOWNERSET				13
#define IM_CHANNELOWNERNOTHERE			14
#define IM_CHANNELPLAYEROPPED			15
#define IM_CHANNELPLAYERDEOPPED			16
#define IM_CHANNELMENOWMODERATOR		40
#define IM_CHANNELPLAYERDEVOICED		41
#define IM_CHANNELPLAYERNOTOP			43
#define IM_CHANNELPLAYERGRANTED			44
#define IM_CHANNELMEGRANTED				45
#define IM_CHANNELMEDEGRANTED			46
#define IM_CHANNELPLAYERDEGRANTED		47
#define IM_CHANNELPASSWORDCLEARED		50

// normal channel stuff
#define IM_CHANNELS						17
#define IM_CHANNELNAMESPACE				18
#define IM_CHANNELMEMBERLISTHEADER		19
#define IM_CHANNELMEMBERLIST			20
#define IM_CHANNELOPLIST                21
#define IM_CHANNELNOTON					22
#define IM_CHANNELMEKICKED				23
#define IM_CHANNELMEVOICED				24
#define IM_CHANNELMEINVITED				25
#define IM_CHANNELSNONE					26
#define IM_CHANNELWRONGPASSWORD			27
#define IM_CHANNELMEDEVOICED			42
#define IM_CHANNELOPLISTOPS				48
#define IM_CHANNELCANTSPEAK				49

// channel toggles
#define IM_CHANNELMODERATEON			28
#define IM_CHANNELMODERATEOFF			29
#define IM_CHANNELLOCALON				30
#define IM_CHANNELLOCALOFF				31


// toggles
#define IM_ANNOUNCINGON					32
#define IM_ANNOUNCINGOFF				33
#define IM_IGNORINGON					34
#define IM_IGNORINGOFF					35
#define IM_INVISIBLEON					36
#define IM_INVISIBLEOFF					37
#define IM_AFKON						38
#define IM_AFKOFF						39



class CEQIMProcessor
{
public:
	CEQIMProcessor(void *pEQIM);
	~CEQIMProcessor(void);

	// ProcessIncoming
	void ProcessIncomingData(unsigned char *buf, int size);
	int PreProcessIncomingData(unsigned char *buf, int size);

	void GotPart(char *buf);
	void GotJoin(char *buf);

	void GotMessage(char *buf, int size);

	void GotBuddy(char *buf, int size);

	int GetMessageType(const char *buf, char *user, char *channel, char *other);

	static const char *GetNameFromMessageType(unsigned long Type);

	char UpdateChannel[128];
	void *m_EQIM;
};
