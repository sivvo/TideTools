#ifndef __GroupPlugin_H__
#define __GroupPlugin_H__

class GroupPlugin
{
	char	groups[14][256];

public : 
	GroupPlugin(class TideUtils* _TU);
	~GroupPlugin();
	
	void parseMessage(char* _msg);

private :

	class TideUtils* TU;

	char*	getGroup(int i);
	char*	getMotd();
	void	clearGroups();
	void	resetGroups();

	void	sendBroadcast(char* _Line);
	void	sendMotd(char* _Line);
	void	sendMyGroup(char* _Line);
	void	sendShowGroup(char* _Line);
	void	sendTellGroup(char* _Line);
	void	sendHelp(char* _Line);
	void	sendFullHelp(char* _Line);
};


#endif