#include "ItemPlugin.h"

#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

#define DATABASEFILE		"Database.txt"
#define TELLHEADERLENGTH	25	
#define ITEMCOMMAND			"!item"
#define FIRSTITEMCOMMAND	"!firstitem"

//===========================================================================
ItemPlugin::ItemPlugin(CEQIMConsole* C)
{
	loadDatabase();
	_Console = C;
}

//===========================================================================
ItemPlugin::~ItemPlugin()
{
}

//===========================================================================
void ItemPlugin::parseMessage(char* _msg)
{
	if (strstr (_msg,"PRIVATE from"))
	{
		if (strstr (_msg,ITEMCOMMAND) )
		{
			sendItem(_msg);
		}
		else
		if (strstr (_msg,FIRSTITEMCOMMAND) )
		{
			sendFirstItem(_msg);
		}

	}
}

//===========================================================================
void ItemPlugin::getNameFromTell(char* _Name, char* _Tell)
{
	strcpy(_Name,_Tell + TELLHEADERLENGTH);

	for(int i=0; i < strlen(_Name) ;i++)
		if ((_Name[i]==20) || (_Name[i]==10) || (_Name[i]=='-'))
			_Name[i]=0;

	strcpy( _Name, strrchr(_Name,'.')+1 );
}

//===========================================================================
void ItemPlugin::getOption(char* _Name, char* _Line, char* _Option)
{
	strcpy(_Name,strstr(_Line,_Option)+ strlen(_Option) +1);

	for(int i=0; i < strlen(_Name) ;i++)
		if (_Name[i]=='\n')
			_Name[i]=0;
}

//===========================================================================
void ItemPlugin::sendItem(char* _Line)
{
	char cAsker[60];
	char cName[60];
	char cAnswer[256];

	getNameFromTell(cAsker, _Line);
	getOption(cName, _Line, ITEMCOMMAND);

	findString(cAsker, cName, false);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request item", cAsker);
	_Console->ChatCommand(cAnswer);
}

//===========================================================================
void ItemPlugin::sendFirstItem(char* _Line)
{
	char cAsker[60];
	char cName[60];
	char cAnswer[256];

	getNameFromTell(cAsker, _Line);
	getOption(cName, _Line, FIRSTITEMCOMMAND);

	findString(cAsker, cName, true);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request item", cAsker);
	_Console->ChatCommand(cAnswer);
}

//===========================================================================
void ItemPlugin::loadDatabase()
{
	int iLength=0;
	printf("ItemPlugin loading database, please wait.\n");
	FILE *file=fopen(DATABASEFILE,"r");

	if (!file)
		return;

	char line[256];

	while(fgets(line, 256, file) != NULL)
	{
		for(int i=0; i< strlen(line); i++)
		{
			if (line[i]=='\n')
			{
				line[i] = 0; 
				break; 
			}
		}
		DataBase.push_back(line);
		iLength++;
	}

	fclose(file);
	printf("Database Loaded : %d items in memory... \n", iLength);
}

//===========================================================================
void ItemPlugin::findString(char* asker, char* _stofind, bool findfirst)
{
	string AskerName(asker);
	string result = "";
	string tellheader = ";tell " + AskerName + " [GroupBot]";

	int iNbfound =0 ;

	for(int i=0; i < DataBase.size(); i++)
	{
		string& sT = DataBase.at(i);
		int num = sT.find(_stofind, 0);

		if ( num > 0 )
		{
			iNbfound++;
			result = tellheader + sT;
			_Console->ChatCommand(result.c_str());

			if (iNbfound>9)
			{
				result = tellheader + " ... too many results";
				_Console->ChatCommand(result.c_str());
				return;
			}

			if (findfirst)
			{
				return;
			}
		}
	}

	if (iNbfound == 0 )
	{
		result = tellheader + " no items found";
		_Console->ChatCommand(result.c_str());
	}
	return;
}