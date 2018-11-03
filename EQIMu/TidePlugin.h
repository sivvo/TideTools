#ifndef __TIDEPLUGIN_H__
#define __TIDEPLUGIN_H__

#include "EQIMConsole.h"

class TidePlugin
{
	char	groups[14][256];

public : 
	TidePlugin();
	~TidePlugin();
	
	void parseMessage(char* _msg, CEQIMConsole* _Console);

private :

	char*	getGroup(int i);
	char*	getMotd();
	void	clearGroups();
	void	resetGroups();

	bool	isAdmin(char* _Name);

	void	getNameFromTell(char* _Name, char* _Tell);
	void	getOption(char* _Name, char* _Line, char* _Option);

	void	sendBroadcast(char* _Line, CEQIMConsole* _Console);
	void	sendMotd(char* _Line, CEQIMConsole* _Console);
	void	sendMyGroup(char* _Line, CEQIMConsole* _Console);
	void	sendShowGroup(char* _Line, CEQIMConsole* _Console);
	void	sendTellGroup(char* _Line, CEQIMConsole* _Console);
	void	sendHelp(char* _Line, CEQIMConsole* _Console);
};


#endif