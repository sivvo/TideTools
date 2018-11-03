//RaidGroups.exp
#include "TidePlugin.h"
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

#define RAIDGROUPFILE		"RaidGroups.exp"		// File to parse ( link to GroupParser )
#define TELLHEADERLENGTH	25						// [22:15:54] -PRIVATE from "
#define TIDEPLUGINVERSION	"v0.2"

#define MOTDCOMMAND			"!motd"
#define MYGROUPCOMMAND		"!mygroup"
#define HELPCOMMAND			"!help"
#define SHOWGROUPCOMMAND	"!showgroup"
#define TELLGROUPCOMMAND	"!tellgroup"
#define BROADCASTCOMMAND	"!broadcast"


//===========================================================================
TidePlugin::TidePlugin()
{
	for(int i=0;i<12;i++)
		groups[i][0]=0;
}

//===========================================================================
TidePlugin::~TidePlugin()
{

}

//===========================================================================
void TidePlugin::parseMessage(char* _msg, CEQIMConsole* _Console)
{
	// check if it's a tell
	if (strstr (_msg,"PRIVATE from"))
	{
		if (strstr (_msg,BROADCASTCOMMAND) )
		{
			sendBroadcast(_msg, _Console);
		}
		else
		if (strstr (_msg,SHOWGROUPCOMMAND) )
		{
			sendShowGroup(_msg, _Console);
		}
		else
		if (strstr (_msg,TELLGROUPCOMMAND) )
		{
			sendTellGroup(_msg, _Console);
		}
		else
		if (strstr (_msg,MYGROUPCOMMAND) )
		{
			sendMyGroup(_msg, _Console);
		}
		else
		if (strstr (_msg,HELPCOMMAND) )
		{
			sendHelp(_msg, _Console);
		}
		else
		if (strstr (_msg,MOTDCOMMAND) )
		{
			sendMotd(_msg, _Console);
		}
	}
}

//===========================================================================
void TidePlugin::clearGroups()
{
	for(int i=0;i<13;i++)
		groups[i][0]=0;
}

//===========================================================================
void TidePlugin::resetGroups()
{
	char	input[4096];

	FILE *file=fopen(RAIDGROUPFILE,"r");

	clearGroups();

	if (!file)
		return;

	for(int i=0; i< 13;i++)
	{
		fgets(groups[i], 256, file);
	}

	fclose(file);
}

//===========================================================================
char* TidePlugin::getGroup(int i)
{
	return groups[i];
}

//===========================================================================
char* TidePlugin::getMotd()
{
	return groups[0];
}

//===========================================================================
bool TidePlugin::isAdmin(char* _Name)
{
	if (
		(strcmp(_Name, "Meemers") == 0) || 
		(strcmp(_Name, "Jakshasis") == 0) || 
		(strcmp(_Name, "Aelith") == 0) || 
		(strcmp(_Name, "Roydal") == 0) || 
		(strcmp(_Name, "Llaenx") == 0)
		)
		return true;

	return false;
}

//===========================================================================
void TidePlugin::getNameFromTell(char* _Name, char* _Tell)
{
	strcpy(_Name,_Tell + TELLHEADERLENGTH);

	for(int i=0; i < strlen(_Name) ;i++)
		if ((_Name[i]==20) || (_Name[i]==10) || (_Name[i]=='-'))
			_Name[i]=0;

	strcpy( _Name, strrchr(_Name,'.')+1 );
}

//===========================================================================
void TidePlugin::getOption(char* _Name, char* _Line, char* _Option)
{
	strcpy(_Name,strstr(_Line,_Option)+ strlen(_Option) +1);

	//remove space in the name and linefeed
	for(int i=0; i < strlen(_Name) ;i++)
		if ((_Name[i]==20) || (_Name[i]==10))
			_Name[i]=0;
}


//===========================================================================
void TidePlugin::sendBroadcast(char* _Line, CEQIMConsole* _Console)
{
	char cAsker[60];
	char cAnswer[256];

	getNameFromTell(cAsker, _Line);

	if (!isAdmin(cAsker))
	{
		
		sprintf(cAnswer, ";tell %s [GroupBot] ERROR : you need administrator privilege for that command", cAsker);
		_Console->ChatCommand(cAnswer);

		sprintf(cAnswer, ";2 [GroupBot] [%s] tryed to use an administrator restricted command", cAsker);
		_Console->ChatCommand(cAnswer);

		return;
	}
	
	resetGroups();
	for(int i=0;i<13;i++)
		_Console->ChatCommand(getGroup(i));
}

//===========================================================================
void TidePlugin::sendMotd(char* _Line, CEQIMConsole* _Console)
{
	char cAsker[60];
	char cAnswer[256];

	//asker name
	getNameFromTell(cAsker, _Line);

	sprintf(cAnswer, ";tell %s %s ", cAsker, getMotd());
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request Motd", cAsker);
	_Console->ChatCommand(cAnswer);
}

//===========================================================================
void TidePlugin::sendShowGroup(char* _Line, CEQIMConsole* _Console)
{
	char cAsker[60];
	char cName[30];
	char cAnswer[256];

	//asker name
	getNameFromTell(cAsker, _Line);

	// Other name
	getOption(cName, _Line, SHOWGROUPCOMMAND);

	for(int i=1; i<13 ;i++)
	{
		char* pipo = strstr (groups[i],cName);
		if ((groups[i]) && (strstr (groups[i],cName)!=0))
		{
			sprintf(cAnswer, ";tell %s [GroupBot]=> %s", cAsker, groups[i]);
			_Console->ChatCommand(cAnswer);

			sprintf(cAnswer, ";2 [GroupBot] [%s] requested group for [%s]", cAsker ,cName);
			_Console->ChatCommand(cAnswer);
			return;
		}
	}

	sprintf(cAnswer, ";tell %s [GroupBot] requested group for [%s], none found", cAsker, cName);
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] requesting group for [%s], none found",cAsker ,cName);
	_Console->ChatCommand(cAnswer);
}


//===========================================================================
void TidePlugin::sendTellGroup(char* _Line, CEQIMConsole* _Console)
{
	char cAsker[60];
	char cName[30];
	char cAnswer[256];

	//asker name
	getNameFromTell(cAsker, _Line);

	if (!isAdmin(cAsker))
	{
		sprintf(cAnswer, ";tell %s [GroupBot] ERROR : you need administrator privilege for that command", cName, cAsker);
		_Console->ChatCommand(cAnswer);

		sprintf(cAnswer, ";2 [GroupBot] [%s] tryed to use an administrator restricted command", cAsker ,cName);
		_Console->ChatCommand(cAnswer);

		return;
	}

	// Other name
	getOption(cName, _Line, TELLGROUPCOMMAND);

	for(int i=1; i<13 ;i++)
	{
		char* pipo = strstr (groups[i],cName);
		if ((groups[i]) && (strstr (groups[i],cName)!=0))
		{
			sprintf(cAnswer, ";tell %s [GroupBot]=> %s", cName, groups[i]);
			_Console->ChatCommand(cAnswer);

			sprintf(cAnswer, ";2 [GroupBot] [%s] requested group for [%s]", cAsker ,cName);
			_Console->ChatCommand(cAnswer);
			return;
		}
	}

	sprintf(cAnswer, ";tell %s [GroupBot] [%s] requested group, none found", cName, cAsker);
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] requesting group for [%s], none found",cAsker ,cName);
	_Console->ChatCommand(cAnswer);
}

//===========================================================================
void TidePlugin::sendMyGroup(char* _Line, CEQIMConsole* _Console)
{
	char cAsker[60];
	char cAnswer[256];

	//asker name
	getNameFromTell(cAsker, _Line);

	for(int i=1; i<13 ;i++)
	{
		char* pipo = strstr (groups[i],cAsker);
		if ((groups[i]) && (strstr (groups[i],cAsker)!=0))
		{
			sprintf(cAnswer, ";tell %s [GroupBot]=> %s", cAsker, groups[i]);
			_Console->ChatCommand(cAnswer);

			sprintf(cAnswer, ";2 [GroupBot] [%s] request group", cAsker);
			_Console->ChatCommand(cAnswer);
			return;
		}
	}

	sprintf(cAnswer, ";tell %s [GroupBot] not grouped ", cAsker);
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request group, not found", cAsker);
	_Console->ChatCommand(cAnswer);
}

//===========================================================================
void TidePlugin::sendHelp(char* _Line, CEQIMConsole* _Console)
{
	char cAsker[60];
	char cAnswer[256];

	//asker name
	getNameFromTell(cAsker, _Line);

	sprintf(cAnswer, ";tell %s [GroupBot] Tide group bot version %s, commands :",cAsker , TIDEPLUGINVERSION);
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";tell %s [GroupBot] %s : display this help", cAsker, HELPCOMMAND);
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";tell %s [GroupBot] %s : tells your group", cAsker, MYGROUPCOMMAND);
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";tell %s [GroupBot] %s : tells you MOTD", cAsker, MOTDCOMMAND);
	_Console->ChatCommand(cAnswer);

	sprintf(cAnswer, ";tell %s [GroupBot] %s CharName : tells you 'CharName' group", cAsker, SHOWGROUPCOMMAND);
	_Console->ChatCommand(cAnswer);

	if (isAdmin(cAsker))
	{
		sprintf(cAnswer, ";tell %s [GroupBot] Admin commands : ", cAsker, TELLGROUPCOMMAND);
		_Console->ChatCommand(cAnswer);

		sprintf(cAnswer, ";tell %s [GroupBot] %s CharName : tells 'CharName' his group", cAsker, TELLGROUPCOMMAND);
		_Console->ChatCommand(cAnswer);

		sprintf(cAnswer, ";tell %s [GroupBot] %s : broadcast groups to channel", cAsker, BROADCASTCOMMAND);
		_Console->ChatCommand(cAnswer);
	}


}