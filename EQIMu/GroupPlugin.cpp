#include "GroupPlugin.h"
#include "TideUtils.h"

#define RAIDGROUPFILE		"RaidGroups.exp"		// File to parse ( link to GroupParser )

#define MOTDCOMMAND			"!motd"
#define MYGROUPCOMMAND		"!mygroup"
#define HELPCOMMAND			"!help"
#define SHOWGROUPCOMMAND	"!showgroup"
#define TELLGROUPCOMMAND	"!tellgroup"
#define BROADCASTCOMMAND	"!broadcast"
#define MYDKPCOMMAND		"!dkp"
#define SHOWDKPCOMMAND		"!showdkp"
#define RELOADDKPCOMMAND	"!reloaddkp"
#define SPELLCOMMAND		"!spell"
#define RELOADSPELLCOMMAND	"!reloadspells"
#define ITEMCOMMAND			"!item"
#define FIRSTITEMCOMMAND	"!firstitem"
#define FULLHELPCOMMAND		"!allhelp"

//===========================================================================
GroupPlugin::GroupPlugin(TideUtils* _TU)
{
	TU = _TU;
	for(int i=0;i<12;i++)
		groups[i][0]=0;
}

//===========================================================================
GroupPlugin::~GroupPlugin()
{
}

//===========================================================================
void GroupPlugin::parseMessage(char* _msg)
{
	// check if it's a tell
	if (strstr (_msg,"PRIVATE from"))
	{
		if (strstr (_msg,BROADCASTCOMMAND) )
		{
			sendBroadcast(_msg);
		}
		else
		if (strstr (_msg,SHOWGROUPCOMMAND) )
		{
			sendShowGroup(_msg);
		}
		else
		if (strstr (_msg,TELLGROUPCOMMAND) )
		{
			sendTellGroup(_msg);
		}
		else
		if (strstr (_msg,MYGROUPCOMMAND) )
		{
			sendMyGroup(_msg);
		}
		else
		if (strstr (_msg,HELPCOMMAND) )
		{
			sendHelp(_msg);
		}
		else
		if (strstr (_msg,MOTDCOMMAND) )
		{
			sendMotd(_msg);
		}
		else
		if (strstr (_msg,FULLHELPCOMMAND) )
		{
			sendFullHelp(_msg);
		}
	}
}	

//===========================================================================
void GroupPlugin::clearGroups()
{
	for(int i=0;i<13;i++)
		groups[i][0]=0;
}

//===========================================================================
void GroupPlugin::resetGroups()
{
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
char* GroupPlugin::getGroup(int i)
{
	return groups[i];
}

//===========================================================================
char* GroupPlugin::getMotd()
{
	return groups[0];
}

//===========================================================================
void GroupPlugin::sendBroadcast(char* _Line)
{
	char cAsker[60];

	TU->getNameFromTell(cAsker, _Line);

	if (!TU->isAdmin(cAsker))
	{		
		TU->NotAdminErrorMessage(cAsker);
		return;
	}
	
	resetGroups();
	for(int i=0;i<13;i++)
		TU->TideOutput(getGroup(i));
}

//===========================================================================
void GroupPlugin::sendMotd(char* _Line)
{
	char cAsker[60];
	char cAnswer[256];

	//asker name
	TU->getNameFromTell(cAsker, _Line);

	sprintf(cAnswer, ";tell %s %s ", cAsker, getMotd());
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request Motd", cAsker);
	TU->TideOutput(cAnswer);
}

//===========================================================================
void GroupPlugin::sendShowGroup(char* _Line)
{
	char cAsker[60];
	char cName[30];
	char cAnswer[256];

	//asker name
	TU->getNameFromTell(cAsker, _Line);

	// Other name
	TU->getOption(cName, _Line, SHOWGROUPCOMMAND);

	for(int i=1; i<13 ;i++)
	{
		char* pipo = strstr (groups[i],cName);
		if ((groups[i]) && (strstr (groups[i],cName)!=0))
		{
			sprintf(cAnswer, ";tell %s [GroupBot]=> %s", cAsker, groups[i]);
			TU->TideOutput(cAnswer);

			sprintf(cAnswer, ";2 [GroupBot] [%s] requested group for [%s]", cAsker ,cName);
			TU->TideOutput(cAnswer);
			return;
		}
	}

	sprintf(cAnswer, ";tell %s [GroupBot] requested group for [%s], none found", cAsker, cName);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] requesting group for [%s], none found",cAsker ,cName);
	TU->TideOutput(cAnswer);
}


//===========================================================================
void GroupPlugin::sendTellGroup(char* _Line)
{
	char cAsker[60];
	char cName[30];
	char cAnswer[256];

	//asker name
	TU->getNameFromTell(cAsker, _Line);

	if (!TU->isAdmin(cAsker))
	{
		TU->NotAdminErrorMessage(cAsker);
		return;
	}

	// Other name
	TU->getOption(cName, _Line, TELLGROUPCOMMAND);

	for(int i=1; i<13 ;i++)
	{
		char* pipo = strstr (groups[i],cName);
		if ((groups[i]) && (strstr (groups[i],cName)!=0))
		{
			sprintf(cAnswer, ";tell %s [GroupBot]=> %s", cName, groups[i]);
			TU->TideOutput(cAnswer);

			sprintf(cAnswer, ";2 [GroupBot] [%s] requested group for [%s]", cAsker ,cName);
			TU->TideOutput(cAnswer);
			return;
		}
	}

	sprintf(cAnswer, ";tell %s [GroupBot] [%s] requested group, none found", cName, cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] requesting group for [%s], none found",cAsker ,cName);
	TU->TideOutput(cAnswer);
}

//===========================================================================
void GroupPlugin::sendMyGroup(char* _Line)
{
	char cAsker[60];
	char cAnswer[256];

	//asker name
	TU->getNameFromTell(cAsker, _Line);

	for(int i=1; i<13 ;i++)
	{
		char* pipo = strstr (groups[i],cAsker);
		if ((groups[i]) && (strstr (groups[i],cAsker)!=0))
		{
			sprintf(cAnswer, ";tell %s [GroupBot]=> %s", cAsker, groups[i]);
			TU->TideOutput(cAnswer);

			sprintf(cAnswer, ";2 [GroupBot] [%s] request group", cAsker);
			TU->TideOutput(cAnswer);
			return;
		}
	}

	sprintf(cAnswer, ";tell %s [GroupBot] not grouped ", cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request group, not found", cAsker);
	TU->TideOutput(cAnswer);
}

//===========================================================================
void GroupPlugin::sendHelp(char* _Line)
{
	char cAsker[60];
	char cAnswer[256];

	//asker name
	TU->getNameFromTell(cAsker, _Line);
	sprintf(cAnswer, ";tell %s \-=-/ TIDE HELP \-=-/ :",cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s to see the full help list type !allhelp :",cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s <Name>: View spell info matching <Name> (5 maximum)", cAsker, SPELLCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s : See your current DKP", cAsker, MYDKPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s CharName : sends you 'CharName' DKP", cAsker, SHOWDKPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s : View your group", cAsker, MYGROUPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s CharName : tells you 'CharName' group", cAsker, SHOWGROUPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s CharName : tells 'CharName' his group [Admin Command]", cAsker, TELLGROUPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s <Name>: sends the links matching <Name> (10 link maximum)", cAsker, ITEMCOMMAND);
	TU->TideOutput(cAnswer);
}

//===========================================================================
void GroupPlugin::sendFullHelp(char* _Line)
{
	char cAsker[60];
	char cAnswer[256];

	//asker name
	TU->getNameFromTell(cAsker, _Line);

	sprintf(cAnswer, ";tell %s \-=-/ Spell Commands \-=-/ :",cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s <Name>: View spell info matching <Name> (5 maximum)", cAsker, SPELLCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s To search for specific spell info use !spell Range: 200 (Mana:/Target:/Type:/Text: etc)",cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s \-=-/ DKP Commands \-=-/ :",cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s : See your current DKP", cAsker, MYDKPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s CharName : sends you 'CharName' DKP", cAsker, SHOWDKPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s : Reload the dkp [Admin Command]", cAsker, RELOADDKPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s \-=-/ Group Commands \-=-/ :",cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s : View your group", cAsker, MYGROUPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s CharName : tells you 'CharName' group", cAsker, SHOWGROUPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s CharName : tells 'CharName' his group [Admin Command]", cAsker, TELLGROUPCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s : Broadcast Groups [Admin Command]", cAsker, BROADCASTCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s : tells you current target", cAsker, MOTDCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s \-=-/ Item Link Commands \-=-/ :",cAsker);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s <Name>: sends the links matching <Name> (10 link maximum)", cAsker, ITEMCOMMAND);
	TU->TideOutput(cAnswer);

	sprintf(cAnswer, ";tell %s %s <Name>: sends the first link matching <Name>", cAsker, FIRSTITEMCOMMAND);
	TU->TideOutput(cAnswer);

}