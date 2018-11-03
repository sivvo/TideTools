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
#include "EQIMDebug.h"
#include "EQIM.h"

#define ALLOW_LOGBUFFER

CEQIMDebug::CEQIMDebug(void)
{
	//strcpy(Outfile,"eqimdebug.txt");
	Initialized=false;
}

CEQIMDebug::~CEQIMDebug(void)
{
	if (Initialized)
	{
		Log("************************************************\n");
		Log("               Session Ends\n");
		Log("************************************************\n");
	}
}

void CEQIMDebug::Initialize(const char *debugfile)
{
	strcpy(Outfile,debugfile);
	Initialized=true;
	Log("************************************************\n");
	Logf("  Session Begins. EQIMBase Version %s\n",EQIMBaseVersion);
	Log("************************************************\n");
}

void CEQIMDebug::Log(const char *out)
{
	if (!Initialized) return;

	CLock L(&S,true);
	FILE *file=fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
	fputs(out,file);
	fclose(file);
//	CStdioFile plog;
//	if (plog.Open(Outfile,CFile::modeCreate|CFile::modeNoTruncate|CFile::modeWrite))
//	{
//		plog.SeekToEnd();
//		plog.WriteString(out);
//		plog.Close();
//	}
//	printf("%s",out);
}

void CEQIMDebug::Logf(const char *format,...)
{
	if (!Initialized) return;
    CHAR szOutput[20480] = {0};
    va_list vaList;
    va_start( vaList, format );
    vsprintf(szOutput,format, vaList);
	CLock L(&S,true);
    FILE *file = fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
	fputs(szOutput,file);
	fclose(file);
//	CStdioFile plog;
//	if (plog.Open(Outfile,CFile::modeCreate|CFile::modeNoTruncate|CFile::modeWrite))
//	{
//		plog.SeekToEnd();
//		plog.WriteString(szOutput);
//		plog.Close();
//	}
}

const char Writechars[257]=
			"................"   // 0-15
			"................"   // 16-31
			" !\"#$%&'()*+,-./"   // 32-47
			"0123456789:;<=>?"   // 48-63
			"@ABCDEFGHIJKLMNO"   // 64-79
			"PQRSTUVWXYZ[\\]^_"   // 80-95
			"`abcdefghijklmno"   // 96-111
			"pqrstuvwxyz{|}~¦"   // 112-127
			"ÇüéâäàåçêëèïîìÄÅ"   // 128-143
			"ÉæÆôöòûùÿÖÜ¢£¥Pƒ"   // 144-159
			"áíóúñÑªº¿¬¬½¼¡«»"   // 160-175
			"¦¦¦¦¦¦¦++¦¦+++++"   // 176-191
			"+--+-+¦¦++--¦-+-"   // 192-207
			"---++++++++¦_¦¦¯"   // 208-223
			"aßGpSsµtFTOd8fen"   // 224-239
			"=±==()÷˜°··vn²¦ ";  // 240-255

void CEQIMDebug::LogBuffer(const char *out, long len, const char *Descriptor)
{
#ifdef ALLOW_LOGBUFFER
	if (!Initialized) return;
	CLock L(&S,true);
	FILE *file=fopen(Outfile,_FO_APPEND);
	if (!file)
		return;
//	CStdioFile file;
//	if (!file.Open(Outfile,CFile::modeCreate|CFile::modeNoTruncate|CFile::modeWrite))
//		return;
//	file.SeekToEnd();

	char block[17];
	block[16]=0;
//	CString Part;
//	CString Out;
        char Part[512];
	char Out[512];

	unsigned short Pos=0;
	fputs("\n______________________________________________________________\n",file);
	fputs(Descriptor,file);
	fputs("\n",file);
	if (len<=0)
	{
		fputs("0000: (null)\n",file);
	}
	while(Pos<len)
	{
		Out[0]=0;
		sprintf(Part,"%04X:  ",Pos);
		strcat(Out,Part);
		for (int i = 0 ; i < 16 ; i++)
		{
			int pI=Pos+i;
			if (pI<len)
			{
				unsigned char ch=out[pI];
				block[i]=Writechars[ch];
				sprintf(Part,"%02X",ch);
				strcat(Out,Part);
			}
			else
			{
				block[i]=' ';
				strcat(Out,"  ");
			}
	
			if (i%4==3 && i>1 && i<15)
			{
				strcat(Out,"-");
			}
			else
				strcat(Out," ");
		}
		strcat(Out," ");
		strcat(Out,&block[0]);
		strcat(Out,"\n");
		fputs(Out,file);
		Pos+=16;
	}
	fputs("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n",file);
	fclose(file);
//	file.Close();
#endif
}



