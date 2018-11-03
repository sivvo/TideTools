/*****************************************************************************
    TEQIM, EQIMd and EQIMu
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

/**************************************
*                                     *
*  Console-based interface for EQIMu  *
*                                     *
***************************************/

#include "../EQIMBase/stdafx.h"
#include "EQIMConsole.h"
#include "EQIMu.h"
#include "TidePlugin.h"
#include "ItemPlugin.h"

// solves input problems for linux
THREAD WINAPI EQIMConsoleInputFunction( LPVOID pParam )
{
	CThread *pThread=(CThread*)pParam;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	pThread->ThreadReady=true;
	Queue<char> *PendingInput=(Queue<char> *)pThread->Info;
	while(!pThread->CloseThread)
	{
		if (kbhit())
		{
			char c=getch();
			PendingInput->Push(c);
		}
		Sleep(10);
	}
	pThread->bThreading=false;
	return (THREAD)0;
}

THREAD WINAPI EQIMConsoleThreadFunction( LPVOID pParam )
{
	CThread *pThread=(CThread*)pParam;
	CEQIMConsole *Console = (CEQIMConsole*)pThread->Info;
	CEQIM *eqim = (CEQIM*)Console->m_EQIM;
	CLock L(&pThread->Threading,true);
	pThread->bThreading=true;
	pThread->ThreadReady=true;
	Queue<char> PendingInput;
	CThread InputThread;
	InputThread.BeginThread(EQIMConsoleInputFunction,&PendingInput);

	char Input[2048]={0};

	bool Connecting=false;        // connecting?
	clock_t First=0;       // connect request times
	clock_t Last=0;        // ---------------------

	bool LoggingIn=false;         // logging in?
	bool ChatConnecting=false;    // chat connecting?
//	bool ChatLoggingIn=false;     // chat logging in?
	bool ChatValidating=false;

	srand( (unsigned)time( NULL ) );

	while(!pThread->CloseThread)
	{
		clock_t now = clock();
		// process Msgs
		if(!Console->Msgs.Empty())
		{
			switch(unsigned long m=Console->Msgs.Pop())
			{
			case MSG_LOGINREADY:
					Connecting=true;
					First=now;
					Last=now;
					eqim->InitializeSession(0x294823);
				break;
			case MSG_LOGINCONNECTED:
					Connecting=false;
					LoggingIn=true;
					Last=now;
					First=now;
					eqim->Login.TryLogin(eqim->sStationName,eqim->sPassword);
				break;
			case MSG_LOGINFAILED:
					LoggingIn=false;
					Last=0;
					First=0;
					Console->Out("Invalid login/password");
				break;
			case MSG_LOGGEDIN:
					LoggingIn=false;
					Last=0;
					First=0;
					Console->Out("Login successful.  Type a server name to pick a server, and then a character name from that server");
					Console->Out("You can pick a new server any time during this process");
					Console->Mode=MODE_LOGIN;
				break;
			case MSG_LOGINCOMPLETE:
					Console->Out("Login completed, shutting that part down...");
//					eqim->Login.KillLoginThread=true;
//					while(eqim->Login.LoginThreading)
//					{
//						Sleep(100);
//					}
					eqim->Login.LoginThread.EndThread();
					eqim->CloseSession();
					eqim->Socket.ShutDown();
					eqim->BeginChat();
				break;
			case MSG_CHATREADY:
					ChatConnecting=true;
					First=now;
					Last=now;
					eqim->InitializeSession(rand()*0x10000+rand());
				break;
			case MSG_CHATCONNECTED:
					ChatConnecting=false;
					ChatValidating=true;
					First=now;
					Last=now;
					// validate
					eqim->Validate();
				break;
			case MSG_CHATRECONNECT:
					if (ChatValidating)
					{
						ChatConnecting=true;
						ChatValidating=false;
						First=now;
						Last=now;
						eqim->InitializeSession(rand()*0x10000+rand());
					}
				break;
			case MSG_CHATVALIDATED:
					ChatValidating=false;
					First=0;
					Last=0;
					Console->Mode=MODE_CHAT;
					Console->Out("All set, you can chat as you wish!");
					Console->LastSend=clock();
				break;
			default:
				{
					//CString Temp;
					//Temp.Format("Invalid MSG received by Console: %d",m);
					Console->Outf("Invalid MSG received by Console: %d",m);
				}
				break;
			}
		}

		if (Connecting)
		{
			if (now-First>=14999)
			{
				Console->Out("Connect timeout");
				Console->Mode=MODE_NONE;
				Connecting=false;
				First=0;
				Last=0;
			}
			else if (now-Last>2000)
			{
				Console->Out("No response, attempting connect again");
				eqim->InitializeSession(0x294823);
				Last=now;
			}
		}
		else if (LoggingIn)
		{
			if (now-First>=25999)
			{
				Console->Out("Login timeout");
				Console->Mode=MODE_NONE;
				LoggingIn=false;
				First=0;
				Last=0;
				eqim->CloseSession();
			}
			else if (now-Last>3000)
			{
				Console->Out("No response, attempting login again");
				Last=now;
				eqim->Login.TryLogin(eqim->sStationName,eqim->sPassword);
			}
		}
		else if (ChatConnecting)
		{
			if (now-First>=24999)
			{
				Console->Out("Connect timeout");
				Console->Mode=MODE_NONE;
				ChatConnecting=false;
				First=0;
				Last=0;
				eqim->CloseSession();
			}
			else if (now-Last>2000)
			{
				Console->Out("No response, attempting to connect again");
				Last=now;
				eqim->InitializeSession(eqim->SessionNumber);
			}
		}
		else if (ChatValidating)
		{
			if (now-First>=24999)
			{
				Console->Out("Connect timeout");
				ChatValidating=false;
				First=0;
				Last=0;
				eqim->CloseSession();
				Console->Mode=MODE_NONE;
			}
			else if (now-Last>2000)
			{
				Console->Out("No response, attempting to validate again");
				Last=now;
				eqim->Validate();
			}
		}

		if (Console->Mode==MODE_CHAT && now-Console->LastSend>15000)
		{
			Console->LastSend=now;
			eqim->KeepAlive();
		}
		
		if(!PendingInput.Empty())
		{
			while(!PendingInput.Empty())
			{
				char c;
				if (Console->Echo)
				{
//					c = getche();
					c=PendingInput.Pop();
					printf("%c",c);
				}
				else
				{
					c=PendingInput.Pop();
//					c = getch();
				}

				switch (c)
				{
				case 10:
#ifdef WIN32
				break;
#endif
				case 13: // end line
#ifdef WIN32
					printf("\n");
#endif
					if (Input[0])
					{
						//Console->Commands.Push(Input);
						switch(Console->Mode)
						{
						case MODE_NONE:
							Console->NoneCommand(Input);
							break;
						case MODE_LOGIN:
							Console->LoginCommand(Input);
							break;
						case MODE_CHAT:
							Console->ChatCommand(Input);
							break;
						case MODE_PRECHAT:
							Console->PreChatCommand(Input);
							break;
						}
						Input[0]=0;
					}
					break;
				case 7:
				case 127:
				case 8: // backspace
	//				if (Input.GetLength())
	//					Input.Delete(Input.GetLength()-1);
					{
					int Len=strlen(Input);
					if (Len)
						Input[Len-1]=0;
					}
					printf("%c%c",32,8);
					break;
				default:
					{
						int Len=strlen(Input);
						Input[Len++]=c;
						Input[Len]=0;
					}
				}
			}
		}
		else
		if(!Console->Display.Empty())
		{
			_ConsoleData Temp=Console->Display.Pop();
			printf("%s",Temp.Data);
			eqim->Debug.Log(Temp.Data);

			Console->TP->parseMessage(Temp.Data, Console);
			Console->IP->parseMessage(Temp.Data);
		}
		else	
			Sleep(10);
	}

	pThread->bThreading=false;
	return (THREAD)1;
}

#define EQIM ((CEQIM*)m_EQIM)

CEQIMConsole::CEQIMConsole(void)
{
	Password=false;
	Echo=true;
	Mode=MODE_NONE;
	LastSend=0;
	TP = new TidePlugin;
	IP = new ItemPlugin(this);
}

CEQIMConsole::~CEQIMConsole(void)
{
	ConsoleThread.EndThread();

	delete TP;
	delete IP;
	/*
	if (Threading)
	{
		KillThread=true;
		while(Threading)
		{
			Sleep(100);
		}
	}
	/**/
}

void CEQIMConsole::Out(const char * Data)
{
#ifdef WIN32
	SYSTEMTIME Time;
	GetLocalTime(&Time);
//	CString OutLine;
	char OutLine[4096];
	sprintf(OutLine,"[%02d:%02d:%02d] %s\n",Time.wHour,Time.wMinute,Time.wSecond,Data);
//	OutLine.Format("[%02d:%02d:%02d] %s\n",Time.wHour,Time.wMinute,Time.wSecond,Data);
	Display.Push(&OutLine[0]);
#else
  char OutLine[4096];
  sprintf(OutLine,"%s\n",Data);
  Display.Push(&OutLine[0]);
#endif
}

void CEQIMConsole::NoneCommand(const char * Command)
{
//	if (Command.IsEmpty())
//		return;
	if (!Command || !Command[0])
		return;

	if (Password)
	{
		Echo=true;
		Password=false;
		strcpy(EQIM->sPassword,Command);
		Out("Done, attempting login.");
		EQIM->Login.BeginLogin();
		return;
	}
//	Command.Trim();

	if (!strnicmp("Login",Command,5)) //Command.Left(5).CompareNoCase("Login")==0)
	{
//		Command.Delete(0,5);
//		Command.TrimLeft();
		DoLogin(&Command[6]);
		return;
	}
	if (!strnicmp("Port",Command,4))//Command.Left(5).CompareNoCase("Port")==0)
	{
//		Command.Delete(0,4);
//		Command.TrimLeft();
		DoPort(&Command[5]);
		return;
	}

	CommonCommand(Command);
}

void CEQIMConsole::LoginCommand(const char * Command)
{
//	Command.Trim();
//	if (Command.IsEmpty())
//		return;
	if (!Command || !Command[0])
		return;

	if (Command[0]=='/')
	{
		CommonCommand(Command);
		return;
	}

	if (IsCharacter(Command))
	{
		strcpy(EQIM->sCharacter,Command);
//		CString Temp;
//		Temp.Format("Trying to get validation for %s.%s...",EQIM->sServer,Command);
		Outf("Trying to get validation for %s.%s...",EQIM->sServer,Command);
		EQIM->Login.TryValidate(EQIM->sServer,EQIM->sCharacter);
		LastSend=clock();
	}
	else
	{
		// server, send worldqry
		strcpy(EQIM->sServer,Command);
//		CString Temp;
//		Temp.Format("Trying to get character list for %s server...",Command);
		Outf("Trying to get character list for %s server...",Command);
		EQIM->Login.ListChars(Command);
		LastSend=clock();
	}
}

void CEQIMConsole::ChatCommand(const char * Command)
{
//	Command.Trim();
//	if (Command.IsEmpty())
//		return;
	if (!Command || !Command[0])
		return;

	if (Command[0]==';')
	{
		// must be in chat mode
//		CString Temp;
//		Temp.Format("Sending: '%s'",Command);
//		Out(Temp);
		EQIM->SendCommand(Command);
		LastSend=clock();
		return;
	}
	CommonCommand(Command);
}

void CEQIMConsole::PreChatCommand(const char * Command)
{
//	Command.Trim();
//	if (Command.IsEmpty())
//		return;
	if (!Command || !Command[0])
		return;

	/*
	if (Command.GetAt(0)==';')
	{
		// must be in chat mode
		EQIM->SendCommand(Command);
		return;
	}
	*/
	CommonCommand(Command);
}

void CEQIMConsole::CommonCommand(const char * Command)
{
	if (!stricmp("/quit",Command))//Command.CompareNoCase("/quit")==0)
	{
		EQIM->CloseSession();
		ConsoleThread.CloseThread=true;
		return;
	}
	Out("Invalid command");
}

void CEQIMConsole::DoLogin(const char * Command)
{
	if (!Command || !Command[0])
	{
		Out("Syntax: Login [station name]");
		return;
	}
	strcpy(EQIM->sStationName,Command);
//	CString Temp;
//	Temp.Format("Station Name: %s. Please enter password.",EQIM->sStationName);
	Outf("Station Name: %s. Please enter password.",EQIM->sStationName);
	Echo=false;
	Password=true;
}

void CEQIMConsole::Go()
{
	Outf("EQIMu Console version [%s] using EQIMBase version [%s]",EQIMuVersion,EQIMBaseVersion);
	Out("Type \"/quit\" any time (except for password entry) to shut down EQIMu.");
	Out("Type \"Login [station name]\" to begin the login process");
	Outf("This session we will be using port %d for communications.  Type \"port [#]\" to use a specific port",EQIM->LocalPort);

	ConsoleThread.BeginThread(EQIMConsoleThreadFunction,this);
//	ConsoleThread = AfxBeginThread(EQIMConsoleThreadFunction,this);
//	while(!Threading)
//	{
//		Sleep(10);
//	}
}

void CEQIMConsole::LoginReady()
{
	Msgs.Push(MSG_LOGINREADY);
//	Out("Sending connect request");
//	EQIM->InitializeSession(0x294823);
}

void CEQIMConsole::LoginConnected()
{
	Msgs.Push(MSG_LOGINCONNECTED);
}

void CEQIMConsole::GotLoginRsp(bool Success)
{
	if (Success)
		Msgs.Push(MSG_LOGGEDIN);
	else
		Msgs.Push(MSG_LOGINFAILED);
}

bool CEQIMConsole::IsCharacter(const char *Name)
{
	for (int i=0 ; i < 10 ; i++)
	{
		if (!stricmp(Characters[i].Name,Name))//Characters[i].Name.CompareNoCase(Name)==0)
		{
			return true;
		}
	}
	return false;
}

void CEQIMConsole::GotWorldRsp(char *Response)
{
//	CString Temp;
//	Temp.Format("Characters on %s: %s",EQIM->sServer,Response);
	Outf("Characters on %s: %s",EQIM->sServer,Response);
        int i;
	for (i = 0 ; i < 10 ; i++)
	{
		Characters[i].Name[0]=0;
	}
	char buf[512];
	strcpy(&buf[0],&Response[0]);
	char *token=strtok(&buf[0],",");
	i=0;
	while(token)
	{
		strcpy(Characters[i++].Name,&token[0]);
		token=strtok(NULL,",");
	}
}

void CEQIMConsole::GotValidateRsp(bool Success)
{
	if (Success)
	{
		Out("Validate successful, time to access chat!");
		Mode=MODE_PRECHAT;
		Msgs.Push(MSG_LOGINCOMPLETE);
	}
	else
	{
		Out("Validation failed");
	}
}

void CEQIMConsole::ChatReady()
{
	Msgs.Push(MSG_CHATREADY);
}

void CEQIMConsole::ChatConnected()
{
	Msgs.Push(MSG_CHATCONNECTED);
}

void CEQIMConsole::ChatValidated(bool Success)
{
	Msgs.Push(MSG_CHATVALIDATED);
}

void CEQIMConsole::GotBuddyStatus(char *buddy, int Status) 
{
	switch(Status)
	{
	case BUDDY_REMOVED:
		Outf("*** %s REMOVED",buddy);
		break;
	case BUDDY_ONLINE:
		Outf("*** %s ONLINE",buddy);
		break;
	case BUDDY_ONLINEAFK:
		Outf("*** %s AFK",buddy);
		break;
	case BUDDY_OFFLINE:
		Outf("*** %s OFFLINE",buddy);
		break;
	case BUDDY_EQIM:
		Outf("*** %s ON EQIM",buddy);
		break;
	case BUDDY_EQIMAFK:
		Outf("*** %s AFK ON EQIM",buddy);
		break;
	default:
		Outf("*** %s UNKNOWN STATUS %d",buddy,Status);
		break;
	}
}

void CEQIMConsole::GotChannelMessage(char *user, char *channel, char *message) 
{
//	CString Temp;
//	Temp.Format("-%s- %s: %s",channel,user,message);
	Outf("-%s- %s: %s",channel,user,message);
}

void CEQIMConsole::GotTell(char *user, char *message) 
{
//	CString Temp;
//	Temp.Format("-PRIVATE from %s-: %s",user,message);
	Outf("-PRIVATE from %s-: %s",user,message);
}

void CEQIMConsole::GotTellEcho(char *user, char *message) 
{
//	CString Temp;
//	Temp.Format("-PRIVATE to %s-: %s",user,message);
	Outf("-PRIVATE to %s-: %s",user,message);
}

void CEQIMConsole::GotMessage(char *message) 
{
//	CString Temp;
//	Temp.Format("- %s",message);
	Outf("- %s",message);
}


void CEQIMConsole::GotChannelsUpdate() 
{
//	CString Temp;
//	Temp.Format("--- %s",data);
//	Out(Temp);
}


void CEQIMConsole::GotDisconnect(bool ServerAction)
{
	Out("Disconnected");
	EQIM->CloseSession();
	EQIM->Socket.ShutDown();
	Mode=MODE_NONE;
}

void CEQIMConsole::GotPart(char *user, char *channel)
{
//	CString Temp;
//	Temp.Format("-%s- User %s has left the channel.",channel,user);
	Outf("-%s- User %s has left the channel.",channel,user);
}

void CEQIMConsole::GotJoin(char *user, char *channel)
{
//	CString Temp;
//	Temp.Format("-%s- User %s joined the channel.",channel,user);
	Outf("-%s- User %s joined the channel.",channel,user);
}

void CEQIMConsole::ChatReconnect()
{
	Msgs.Push(MSG_CHATRECONNECT);
}

void CEQIMConsole::DoPort(const char * Command)
{
	EQIM->LocalPort=atoi(Command);
//	CString Temp;
//	Temp.Format("Now using port %d",EQIM->LocalPort);
	Outf("Now using port %d",EQIM->LocalPort);
}

void CEQIMConsole::Outf(const char *szFormat,...)
{
    CHAR szOutput[20480] = {0};
    va_list vaList;
    va_start( vaList, szFormat );
    vsprintf(szOutput,szFormat, vaList);

	Out(szOutput);
//	SYSTEMTIME Time;
//	GetLocalTime(&Time);
//	OutLine.Format("[%02d:%02d:%02d] %s\n",Time.wHour,Time.wMinute,Time.wSecond,szOutput);
//	Display.Push(OutLine);
}
