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
#include "EQIMProcessor.h"
#include "EQIM.h"
#include "EQIMInterface.h"

#define EQIM ((CEQIM*)m_EQIM)
#define Interface ((CEQIMInterface*)(EQIM->m_Interface))

//#define DebugTry(x) EQIM->Debug.Logf("Trying %s\n",#x);x;EQIM->Debug.Logf("%s complete\n",#x)
#define DebugTry(x) x

CEQIMProcessor::CEQIMProcessor(void *pEQIM)
{
	m_EQIM=pEQIM;
}

CEQIMProcessor::~CEQIMProcessor(void)
{
}

void CEQIMProcessor::ProcessIncomingData(unsigned char *buf, int size)
{
	// ok first we have to check the opcode and determine how to break up this info
	static unsigned char OverSized[8192]={0};
	static unsigned short OverSize=0;
	if (size<=0 || buf==0)
		return;
	EQIM->Debug.LogBuffer((char*)buf,size,"ProcessIncomingData");

	if (buf[0]!=0)
	{
		switch(buf[0])
		{
		case 0x01:
			DebugTry(Interface->ChatValidated(buf[1]!=0));
			break;
		case 0x02:
			// current channels
			DebugTry(EQIM->Channels.UpdateChannels((char*)&buf[1]));
			DebugTry(Interface->GotChannelsUpdate());

			break;
		case 0x03:
			// chat message
			DebugTry(GotMessage((char *)&buf[1],size-2));
			break;
		case 0x04:
			// joins channel
			DebugTry(GotJoin((char *)&buf[1]));
			break;
		case 0x05:
			// leaves channel
			DebugTry(GotPart((char *)&buf[1]));
			break;
		case 0x06:
			// buddy list
			DebugTry(GotBuddy((char *)&buf[1],size-2));
			break;
		default:
			// invalid, log it
			EQIM->Debug.LogBuffer((char *)&buf[0],size,"Received invalid or unexpected data");
			break;
		}
		return;
	}
	switch(buf[1])
	{
	case 0x02:
		// session initialization
		EQIM->GotSessionInfo((in_session*)&buf[2]);
		Interface->ChatConnected();
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
		DebugTry(Interface->ChatReconnect());
		break;
	case 0x06:
		// keepalive
		break;
	case 0x09:
		// ack request
		if (EQIM->Sequencer.GotSeq(htons(*(unsigned short*)&buf[2])))
		{
			ProcessIncomingData(&buf[4],size-4);
		}
		break;
	case 0x0d:
		// over-sized data
		if (EQIM->Sequencer.GotSeq(htons(*(unsigned short*)&buf[2])))
		{
			memcpy(&OverSized[OverSize],&buf[6],size-6);
			if (size<0x1FD)
			{
				ProcessIncomingData(OverSized,OverSize+size-6);
				OverSize=0;
			}
			else
			{
				OverSize=size-6;
			}
		}
		break;
	case 0x11: // ack response-- out of sequence
		ProcessIncomingData(&buf[4],size-4);
		DebugTry(EQIM->Sequencer.GotError(htons(*(unsigned short*)&buf[2])));
		break;
	case 0x15:
		// ack response
		// yippie they got it, lets have a party. OR.. continue with our lives.
		// 0 1 2 3
		ProcessIncomingData(&buf[4],size-4);
		DebugTry(EQIM->Sequencer.GotAck(htons(*(unsigned short*)&buf[2])));
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
		DebugTry(EQIM->GotDisconnect(true));
		break;
	case 0x1E: // Invalid data I believe
		EQIM->Debug.LogBuffer((char *)&buf[0],size,"Unknown Op-Code 0x1E");
		break;
	default:
		// invalid, log it
		EQIM->Debug.LogBuffer((char *)&buf[0],size,"Received invalid or unexpected data");
		break;
	}
}

int CEQIMProcessor::PreProcessIncomingData(unsigned char *buf, int size)
{
	if (size<=2)
		return size;

	if (buf[1]!=0x02)
	{
		unsigned short CRC=htons(*(unsigned short *)&buf[size-2]);
		size-=2; // strip CRC
		unsigned short GeneratedCRC=EQIM->Socket.CRC16(&buf[0],size,false);
		if (GeneratedCRC!=CRC)
		{
			EQIM->Debug.Logf("GeneratedCRC!=CRC %04X(Gen) vs %04X(Real)\n",GeneratedCRC,CRC);
		}

		EQIM->Encoder.Decode(&buf[2],size-2);
	}
	return size;
}

void CEQIMProcessor::GotMessage(char *buf, int size)
{
	static int NextMessage=IM_UNKNOWN;
	int Channel=0;
	int User=1+(int)strlen((char*)&buf[Channel]);
	int Message=User+(int)strlen((char*)&buf[User])+1;

	int MessageLen=511-Message;
	char *Pos;
	while(Pos=strstr(&buf[Message],"&PCT;"))
	{
		// strip 4 characters
		// length is 512-(Pos-&message[0])
		memcpy(&Pos[1],&Pos[5],MessageLen-(Pos-&buf[Message]));
		Pos[0]='%';
	}

	if (buf[Channel])
	{
		if (buf[Channel]=='$')
		{
			Channel++;
			char Me[256]={0};
			sprintf(Me,"%s.%s",EQIM->sServer,EQIM->sCharacter);
			if (!stricmp(&buf[Channel],Me))
			{
				Interface->GotTell(&buf[User],&buf[Message]);
			}
			else
				Interface->GotTellEcho(&buf[Channel],&buf[Message]);
		}
		else
			Interface->GotChannelMessage(&buf[User],&buf[Channel],&buf[Message]);
	}
	else
	{
		char user[512];
		char channel[512];
		char other[512];
		DebugTry(int Msg=GetMessageType(&buf[Message],user,channel,other));
		// clean up user
		if (user[0] && !strchr(user,'.'))
		{
			char temp[128];
			sprintf(temp,"%s.%s",EQIM->sServer,user);
			strcpy(user,temp);
		}
		// clean up channel
		if (char *Pos=strchr(channel,'('))
			Pos[0]=0;
		if (channel[0] && !strchr(channel,'.'))
		{
			char temp[128];
			sprintf(temp,"%s.%s",EQIM->sServer,channel);
			strcpy(channel,temp);
		}

		if (NextMessage==IM_CHANNELMEMBERLIST)
		{
			if (Msg==IM_UNKNOWN)
			{
				// during update
				Msg=IM_CHANNELMEMBERLIST;
				ChannelNode *node=EQIM->Channels.FindChannelNode(UpdateChannel);
				if (node)
				{
					if (node->Members.UpdateMembers(other))
						NextMessage=IM_UNKNOWN;
				}
			}
		}
		else if (NextMessage==IM_CHANNELOPLISTOPS)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(UpdateChannel);
			if (Msg==IM_UNKNOWN)
			{
				Msg=IM_CHANNELOPLISTOPS;
				if (node)
				{
					if (node->Members.UpdateAutoOps(other))
						NextMessage=IM_UNKNOWN;
				}
				
			}
			else 
			{
				if (node)
				{
					Interface->GotChannelMembersUpdate(UpdateChannel);
				}
				NextMessage=IM_UNKNOWN;
			}
		}


		if (Msg==IM_CHANNELMEMBERLISTHEADER)
		{
			// begin update
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				strcpy(UpdateChannel,channel);
				NextMessage=IM_CHANNELMEMBERLIST;
				node->Members.BeginUpdateMembers(atoi(other));
			}
		} 
		else if (Msg==IM_CHANNELOPLIST)
		{
			// begin update
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				strcpy(UpdateChannel,channel);
				NextMessage=IM_CHANNELOPLISTOPS;
				node->Members.BeginUpdateAutoOps();
			}
		}
		else if (Msg==IM_CHANNELOWNERSET)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				node->Members.SetOwner(user);
			}
		}
		else if (Msg==IM_CHANNELMEOPPED || Msg==IM_CHANNELMENOWMODERATOR || Msg==IM_CHANNELMEGRANTED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				char MyName[256];
				sprintf(MyName,"%s.%s",EQIM->sServer,EQIM->sCharacter);
				node->Members.AddMember(MyName,CM_OP);
			}
		}
		else if (Msg==IM_CHANNELMEDEGRANTED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				char MyName[256];
				sprintf(MyName,"%s.%s",EQIM->sServer,EQIM->sCharacter);
				node->Members.AddMember(MyName,CM_NORMAL);
			}
		}
		else if (Msg==IM_CHANNELMEVOICED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				char MyName[256];
				sprintf(MyName,"%s.%s",EQIM->sServer,EQIM->sCharacter);
				EQIMChannelMember Member;
				if (node->Members.FindMember(MyName,Member))
				{
					if (Member.Status==CM_NORMAL)
					{
						node->Members.AddMember(MyName,CM_VOICE);
					}
				}
			}
		}
		else if (Msg==IM_CHANNELMEDEVOICED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				char MyName[256];
				sprintf(MyName,"%s.%s",EQIM->sServer,EQIM->sCharacter);
				EQIMChannelMember Member;
				if (node->Members.FindMember(MyName,Member))
				{
					if (Member.Status==CM_VOICE)
					{
						node->Members.AddMember(MyName,CM_NORMAL);
					}
				}
			}
		}
		else if (Msg==IM_CHANNELMODERATEON)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				node->Channel.Moderated=true;
			}
		}
		else if (Msg==IM_CHANNELMODERATEOFF)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				node->Channel.Moderated=false;
			}
		}
		else if (Msg==IM_CHANNELPLAYERVOICED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				EQIMChannelMember Member;
				if (node->Members.FindMember(user,Member))
				{
					if (Member.Status==CM_NORMAL)
					{
						node->Members.AddMember(user,CM_VOICE);
					}
				}
			}
		}
		else if (Msg==IM_CHANNELPLAYERDEVOICED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				EQIMChannelMember Member;
				if (node->Members.FindMember(user,Member))
				{
					if (Member.Status==CM_VOICE)
					{
						node->Members.AddMember(user,CM_NORMAL);
					}
				}
			}
		}
		else if (Msg==IM_CHANNELPLAYEROPPED || Msg==IM_CHANNELPLAYERGRANTED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				EQIMChannelMember Member;
				if (node->Members.FindMember(user,Member))
				{
					if (Member.Status!=CM_OP && Member.Status!=CM_OWNER)
					{
						node->Members.AddMember(user,CM_OP);
					}
					if (Msg==IM_CHANNELPLAYEROPPED)
						node->Members.AutoOpMember(user);
				}
			}
		}
		else if (Msg==IM_CHANNELPLAYERDEOPPED || Msg==IM_CHANNELPLAYERDEGRANTED)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				EQIMChannelMember Member;
				if (node->Members.FindMember(user,Member))
				{
					if (Member.Status!=CM_NORMAL)
					{
						node->Members.AddMember(user,CM_NORMAL);
					}
					if (Msg==IM_CHANNELPLAYERDEOPPED)
						node->Members.AutoOpMember(user,false);
				}
			}
		}
		else if (Msg==IM_CHANNELOWNERSET)
		{
			ChannelNode *node=EQIM->Channels.FindChannelNode(channel);
			if (node)
			{
				EQIMChannelMember Member;
				if (node->Members.FindMember(user,Member))
				{
					node->Members.AddMember(user,CM_OWNER);
				}
			}
		}

		Interface->GotMessage(Msg,user,channel,other);

		Interface->GotMessage(&buf[Message]);
	}
}

void CEQIMProcessor::GotBuddy(char *buf, int size)
{
	if (buf[0]==BUDDY_REMOVED)
		EQIM->Buddies.RemoveBuddy(&buf[1]);
	else
		EQIM->Buddies.AddBuddy(&buf[1],buf[0]);
	Interface->GotBuddyStatus(&buf[1],buf[0]);
}

void CEQIMProcessor::GotPart(char *buf)
{
	int Channel=0;
	int User=1+(int)strlen((char*)&buf[Channel]);
	char fulluser[512];
	if (strchr(&buf[User],'.'))
		strcpy(fulluser,&buf[User]);
	else
		sprintf(fulluser,"%s.%s",EQIM->sServer,&buf[User]);
	char fullchannel[512];
	if (strchr(&buf[Channel],'.'))
		strcpy(fullchannel,&buf[Channel]);
	else
		sprintf(fullchannel,"%s.%s",EQIM->sServer,&buf[Channel]);
	EQIM->Channels.RemoveChannelMember(fullchannel,fulluser);
	Interface->GotPart(fulluser,fullchannel);
}

void CEQIMProcessor::GotJoin(char *buf)
{
	int Channel=0;
	int User=1+(int)strlen((char*)&buf[Channel]);
	char fulluser[512];
	if (strchr(&buf[User],'.'))
		strcpy(fulluser,&buf[User]);
	else
		sprintf(fulluser,"%s.%s",EQIM->sServer,&buf[User]);
	char fullchannel[512];
	if (strchr(&buf[Channel],'.'))
		strcpy(fullchannel,&buf[Channel]);
	else
		sprintf(fullchannel,"%s.%s",EQIM->sServer,&buf[Channel]);
	EQIM->Channels.AddChannelMember(fullchannel,fulluser,CM_NORMAL);
	Interface->GotJoin(fulluser,fullchannel);
}

struct _EQIMMessage
{
	int message;
	char *text;
};

_EQIMMessage Messages[]=
{
	{IM_CHANNELNAMESPACE,"Only players in the same namespace can join this channel."},
	{IM_CHANNELSNONE,"You are not on any channels"},
	{IM_BUDDYLISTMODIFIED,"Buddy list modified."},
	{IM_ANNOUNCINGON,"Announcing now on"},
	{IM_ANNOUNCINGOFF,"Announcing now off"},
	{IM_IGNORINGON,"Ignoring private messages from outside your namespace"},
	{IM_IGNORINGOFF,"You can now hear private messages from outside your namespace"},
	{IM_AFKON,"Away from keyboard on"},
	{IM_AFKOFF,"Away from keyboard off"},
	{IM_INVISIBLEON,"Invisible mode on"},
	{IM_INVISIBLEOFF,"Invisible mode off"},
	{IM_CHANNELMODERATEON,"Channel %C is now moderated"},
	{IM_CHANNELMODERATEOFF,"Channel %C is now unmoderated"},
	{IM_CHANNELLOCALOFF,"Channel %C is now open to players from any namespace"},
	{IM_CHANNELLOCALON,"Channel %C is now restricted to local-namespace players only."},
	{IM_CHANNELOPLIST,"Channel %C op-list: (Owner=%U)"},
	{IM_CHANNELPLAYEROPPED,"Player %U has been added to op-list on channel %C"},
	{IM_CHANNELS,"Channels: %O"},
	{IM_CHANNELNAMESPACE,"You are in namespace %O."},
	{IM_CHANNELNOPLAYER,"Player %U not found on channel %C"},
	{IM_CHANNELNOPLAYER,"Player %U not found online"},
	{IM_CHANNELALREADYPLAYER,"Player %U is already in the channel"},
	{IM_CHANNELPLAYERINVITED,"Player %U has been invited/permitted to join channel %C"},
	{IM_CHANNELMEINVITED,"Player %U has invited you to join a channel %C"},
	{IM_CHANNELPLAYERDEOPPED,"Player %U has been removed from op-list for channel %C"},
	{IM_CHANNELOWNERNOTHERE,"Player must be in the channel with you to transfer ownership"},
	{IM_CHANNELOWNERSET,"Channel %C owner set to %U"},
	{IM_CHANNELNOPERMISSION,"You do not have permission to %O on channel %C"},
	{IM_CHANNELPASSWORDCHANGED,"Password changed for channel %C"},
	{IM_CHANNELPASSWORDCLEARED,"Password cleared for channel %C"},
	{IM_CHANNELPLAYERKICKED,"Player %U kicked from channel %C"},
	{IM_CHANNELMEKICKED,"You have been kicked from channel %C"},
	{IM_CHANNELPLAYERVOICED,"Player %U has been given voice on channel %C"},
	{IM_CHANNELPLAYERDEVOICED,"Player %U has voice taken away on channel %C"},
	{IM_CHANNELMEDEVOICED,"You have lost voice on channel %C"},
	{IM_CHANNELMEVOICED,"You have been given voice on channel %C"},
	{IM_CHANNELMEOPPED,"You have been added to op-list on channel %C"},
	{IM_NOPLAYER,"Could not find player %U"},
	{IM_CHANNELWRONGPASSWORD,"Incorrect password for channel %C"},
	{IM_CHANNELNOTOWNER,"You are not the owner of channel %C"},
	{IM_CHANNELMEMBERLISTHEADER,"Channel %C(%O) members:"},
	{IM_INVALIDCOMMAND,"Invalid Command: %O"},
	{IM_CHANNELMENOWMODERATOR,"You are now the moderator for channel %C"},
	{IM_CHANNELMEGRANTED,"You have been granted powers on channel %C"},
	{IM_CHANNELPLAYERGRANTED,"Player %U has been granted powers on channel %C"},
	{IM_CHANNELPLAYERNOTOP,"Player %U not found on op-list for channel %C"},
	{IM_CHANNELPLAYERDEGRANTED,"Player %U has had powers removed on channel %C"},
	{IM_CHANNELMEDEGRANTED,"You have had powers removed on channel %C"},
	{IM_CHANNELCANTSPEAK,"You cannot speak on moderated channel %C"},
	{-1,""},
};

int CEQIMProcessor::GetMessageType(const char *buf, char *user, char *channel, char *other)
{
	int NewPos;
	char val[2048];             
	char temp[2048];
	int buflen=(int)strlen(buf);
	bool bUser=false;
	bool bChannel=false;
	bool bOther=false;
	char curvar=0;
	char *varptr=0;
	char *next=0;

	user[0]=0;
	channel[0]=0;
	other[0]=0;

	for (int i = 0 ; Messages[i].message>=0 ; i++)
	{
		bUser=false;
		bChannel=false;
		bOther=false;
		strcpy(temp,Messages[i].text);
		// 012345678901234567890123456
		// Player %U not found online
		while (varptr=strchr(temp,'%')) // varptr=&temp[7]
		{
			int Pos=varptr-&temp[0];    // pos = 7
			// see if we match to here..
			if (strncmp(buf,temp,Pos))  // strncmp("Player ","Player ",7)
			{
				goto parsenomatch; // dont bother continuing
			}
			// get which variable it is..
			curvar=varptr[1];           // curvar='U'
			// remove this part of the string..
			memmove(varptr,&varptr[2],strlen(&varptr[2])+1); 
			// 0123456789012345678901234
			// Player  not found online
			// varptr=7
			if (varptr[0]==0)
			{ // end of line, copy the rest of the data from the buffer
				strcpy(varptr,&buf[Pos]);
				// copy this same data to the destination variable
				switch(curvar)
				{
				case 'C':
					bChannel=true;
					strcpy(channel,&buf[Pos]);
					break;
				case 'U':
					bUser=true;
					strcpy(user,&buf[Pos]);
					break;
				case 'O':
					bOther=true;
					strcpy(other,&buf[Pos]);
					break;
				}
			}
			else
			{
				// find next %
				next=strchr(temp,'%'); // next=0
				if (next)
				{
					// 01234567890123456789012345
					// Player  not found online%
					NewPos=next-&varptr[0]; // 24-7 = 17
				}
				else
				{
					//        123456789012345678
					// Player  not found online
					NewPos=strlen(varptr); // NewPos=17
				}
				// now NewPos holds the length of what we're searching for, and varptr
				// is the start.
				if (NewPos)
				{
												//      01234567890123456
					strncpy(val,varptr,NewPos); // val=" not found online"
					val[NewPos]=0;
					next=strstr(&buf[Pos],val);
					// now we have the END of our data stored in next, and &buf[Pos] is start
					if (!next)
					{
						goto parsenomatch; // seeya, no match
					}
					NewPos=next-&buf[Pos]; // length of data to copy
					// make space in temp
					memmove(&varptr[NewPos],varptr,strlen(varptr)+1);
					// move new data in
					memcpy(varptr,&buf[Pos],NewPos);
					// copy this same data to the destination variable
					switch(curvar)
					{
					case 'C':
						bChannel=true;
						memcpy(channel,&buf[Pos],NewPos);
						channel[NewPos]=0;
						break;
					case 'U':
						bUser=true;
						memcpy(user,&buf[Pos],NewPos);
						user[NewPos]=0;
						break;
					case 'O':
						bOther=true;
						memcpy(other,&buf[Pos],NewPos);
						other[NewPos]=0;
						break;
					}
				}
			}
		}

		if (!strcmp(buf,temp))
		{
			if (!bChannel)
				channel[0]=0;
			if (!bUser)
				user[0]=0;
			if (!bOther)
				other[0]=0;
//			EQIM->Debug.Logf("GetMessageType() returns %d\n",Messages[i].message);
			return Messages[i].message;
		}
parsenomatch:;
	}
	strcpy(other,buf);
//EQIM->Debug.Log("GetMessageType() returns IM_UNKNOWN\n");

	return IM_UNKNOWN;
}

const char *CEQIMProcessor::GetNameFromMessageType(unsigned long Type)
{
#define MessageType(defn) case defn: return #defn;
	switch(Type)
	{
	MessageType(IM_CHANNELCANTSPEAK);
	MessageType(IM_CHANNELOPLISTOPS);
	MessageType(IM_CHANNELMEGRANTED);
	MessageType(IM_CHANNELMEDEGRANTED);
	MessageType(IM_CHANNELPLAYERGRANTED);
	MessageType(IM_CHANNELPLAYERDEGRANTED);
	MessageType(IM_CHANNELPLAYERNOTOP);
	MessageType(IM_BUDDYLISTMODIFIED);
	MessageType(IM_NOPLAYER);
	MessageType(IM_INVALIDCOMMAND);
// channel operator stuff
	MessageType(IM_CHANNELNOPERMISSION);
	MessageType(IM_CHANNELNOTOWNER);
	MessageType(IM_CHANNELNOPLAYER);
	MessageType(IM_CHANNELALREADYPLAYER);
	MessageType(IM_CHANNELPLAYERKICKED);
	MessageType(IM_CHANNELPLAYERVOICED);
	MessageType(IM_CHANNELPASSWORDCHANGED);
	MessageType(IM_CHANNELPASSWORDCLEARED);
	MessageType(IM_CHANNELPLAYERINVITED);
	MessageType(IM_CHANNELMEOPPED);
	MessageType(IM_CHANNELOWNERSET);
	MessageType(IM_CHANNELOWNERNOTHERE);
	MessageType(IM_CHANNELPLAYEROPPED);
	MessageType(IM_CHANNELPLAYERDEOPPED);
	MessageType(IM_CHANNELMENOWMODERATOR);

	// normal channel stuff
	MessageType(IM_CHANNELS);
	MessageType(IM_CHANNELNAMESPACE);
	MessageType(IM_CHANNELMEMBERLISTHEADER);
	MessageType(IM_CHANNELMEMBERLIST);
	MessageType(IM_CHANNELOPLIST);
	MessageType(IM_CHANNELNOTON);
	MessageType(IM_CHANNELMEKICKED);
	MessageType(IM_CHANNELMEVOICED);
	MessageType(IM_CHANNELMEINVITED);
	MessageType(IM_CHANNELSNONE);
	MessageType(IM_CHANNELWRONGPASSWORD);

	// channel toggles
	MessageType(IM_CHANNELMODERATEON);
	MessageType(IM_CHANNELMODERATEOFF);
	MessageType(IM_CHANNELLOCALON);
	MessageType(IM_CHANNELLOCALOFF);


	// toggles
	MessageType(IM_ANNOUNCINGON);
	MessageType(IM_ANNOUNCINGOFF);
	MessageType(IM_IGNORINGON);
	MessageType(IM_IGNORINGOFF);
	MessageType(IM_INVISIBLEON);
	MessageType(IM_INVISIBLEOFF);
	MessageType(IM_AFKON);
	MessageType(IM_AFKOFF);
	case IM_UNKNOWN:
	default:
		return "IM_UNKNOWN";
	}
}



