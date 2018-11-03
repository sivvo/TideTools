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

// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once
// WINDOWS/MFC

#ifdef WIN32

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
#include <stdio.h>
#include <tchar.h>
#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// some CString constructors will be explicit

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers
#endif

#include <afx.h>
#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <iostream>
//#include <afxmt.h>
#include "WinThreading.h"
#include "winsock2.h"
#pragma comment(lib,"ws2_32.lib")
#define _FO_READ "rt"
#define _FO_WRITE "wt"
#define _FO_APPEND "at"
#define socklen_t int
#else
// NON-WIN32 -- UNIX STUFF
#define WINAPI
#define LPVOID void *
#define DWORD unsigned long
#define UINT unsigned long
#define CHAR char
#define VOID void
#define ZeroMemory(_ptr_,_size_) memset(_ptr_,0,_size_)
#define stricmp strcasecmp
#define strnicmp strncasecmp
#include <netdb.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <sys/ioctl.h>
#include <memory.h>
#include <errno.h>
#include <unistd.h>
#define SOCKET int
#define INVALID_SOCKET (-1)
#define SD_BOTH SHUT_RDWR
#define SOCKET_ERROR (-1)

#include <stdio.h>
#include <stdarg.h>
#include <stdlib.h>
#include <unistd.h>
#include "UnixThreading.h"
#define _FO_READ "r"
#define _FO_WRITE "w"
#define _FO_APPEND "a"
#define closesocket close
#define ioctlsocket ioctl
#include "EQIMStructs.h"
#define SOCKADDR sockaddr
#define SOCKADDR_IN sockaddr
#define LPHOSTENT hostent*
#define LPIN_ADDR in_addr*
#define TRUE 1
#define FALSE 0
#define WSAGetLastError() errno
#define WSAEISCONN EISCONN
#define WSAENOTCONN ENOTCONN
#define WSAECONNRESET ECONNRESET
#define WSAEWOULDBLOCK EWOULDBLOCK
#define WSAENETRESET ENETRESET
#define WSAENOTSOCK ENOTSOCK
#define WSAESHUTDOWN ESHUTDOWN
#define WSAEINVAL EINVAL
#define WSAECONNABORTED ECONNABORTED

#endif
#ifndef MSG_NOSIGNAL
#define MSG_NOSIGNAL 0
#endif