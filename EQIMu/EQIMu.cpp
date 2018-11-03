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

// EQIMu.cpp : Defines the entry point for the console application.
//

#include "../EQIMBase/stdafx.h"
#include "../EQIMBase/EQIM.h"
#include <stdio.h>
#include "EQIMConsole.h"
#include "EQIMu.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

void Pause()
{
		printf("<Press any key.>");
		do
		{
			Sleep(20);
		}
		while (!kbhit());
		getch();
		printf("\n\n");
}

using namespace std;

#ifdef WIN32
CWinApp theApp;
int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	// initialize MFC and print and error on failure
	if (!AfxWinInit(::GetModuleHandle(NULL), NULL, ::GetCommandLine(), 0))
	{
		// TODO: change error code to suit your needs
		_tprintf(_T("Fatal Error: MFC initialization failed\n"));
		nRetCode = 1;
	}
	else
	{
		// TODO: code your application's behavior here.
		WSADATA wsa;
		if (WSAStartup(MAKEWORD(2,0),&wsa) || (HIBYTE(wsa.wVersion) != 0) || (LOBYTE(wsa.wVersion) != 2))
		{
			printf("Could not initialize Winsock\n");
			return 1;
		}

		CEQIM eqim;
		CEQIMConsole console;

		console.AttachEQIM(&eqim);
		eqim.AttachInterface(&console);
		eqim.Debug.Initialize("EQIMuDebug.txt");
		console.Go();


		while(console.ConsoleThread.bThreading)
		{
			Sleep(100);
		}

		WSACleanup();
	}

	return nRetCode;
}
#else
#include <stdio.h>
#include <termios.h>
// keyboard hackjob
struct termios term, oterm;
void init_keyboard()
{
  /* get the terminal settings */
  tcgetattr(0, &oterm);

  /* get a copy of the settings, which we modify */
  memcpy(&term, &oterm, sizeof(term));

  /* put the terminal in non-canonical mode, any
     reads timeout after 0.1 seconds or when a
     single character is read */
  term.c_lflag = term.c_lflag & ~(ICANON |ECHO);
  term.c_cc[VMIN] = 0;
  term.c_cc[VTIME] = 1;
  tcsetattr(0, TCSANOW, &term);
}

void close_keyboard()
{
  /* reset the terminal to its original state */
  tcsetattr(0, TCSANOW, &oterm);
}

int kbhit(void)
{
  int c = 0;


  term.c_cc[VMIN] = 0;
  term.c_cc[VTIME] = 1;
  tcsetattr(0, TCSANOW, &term);

  /* get input - timeout after 0.1 seconds or 
     when one character is read. If timed out
     getchar() returns -1, otherwise it returns
     the character */
  c=getchar();

  /* if we retrieved a character, put it back on
     the input stream */
  if (c != -1)
    ungetc(c, stdin);

  /* return 1 if the keyboard was hit, or 0 if it
     was not hit */
  return ((c!=-1)?1:0);
}

/********************************************************/

int getch()
{
  int c, i;
  
  term.c_cc[VMIN] = 1;
  term.c_cc[VTIME] = 0;
  tcsetattr(0, TCSANOW, &term);

  /* get a character. c is the character */
  c=getchar();

  /* return the charcter */
  return c;
}
int main(int argc, char *argv[])
{
	init_keyboard();
                CEQIM eqim;
                CEQIMConsole console;

                console.AttachEQIM(&eqim);
                eqim.AttachInterface(&console);
                eqim.Debug.Initialize("EQIMuDebug.txt");
                console.Go();


                while(console.ConsoleThread.bThreading)
                {
                        Sleep(100);
                }
	close_keyboard();
	return 0;
}
#endif
