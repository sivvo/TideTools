
SELECT name from names INTO ARRAY ar_name ORDER BY name
nFile = FCREATE("c:\twinkratio.txt")
FPUTS(nFile, "*** Main/Twink DKP Ratio : "+DTOC(DATE())+"***")
FOR i = 1 TO ALEN(Ar_name,1)
	lname = ar_name[i]
	SELECT sum(dkp) as dkp FROM loots WHERE name = lname into CURSOR tmp
	lmain = dkp
	?lname
	*?lmain
	IF lmain > 0
		SELECT sum(dkp) as dkp FROM loots WHERE name = lname AND twink=.T. into CURSOR tmp
		ltwink = dkp
		IF ltwink > 0
		*?ltwink
			?ltwink/lmain * 100
			
			lcString = PADR(ALLTRIM(lname), 20, " ") + ALLTRIM(STR(ltwink/lmain *100,5,3))
			FPUTS(nFile, lcString)
		ENDIF
	ENDIF
ENDFOR
FCLOSE(nFIle)

*!*	lname = "Jakshasis"
*!*	SELECT sum(dkp) as dkp FROM loots WHERE name = lname into CURSOR tmp
*!*	*AND twink=.f. into CURSOR tmp
*!*	lmain = dkp
*!*	?lname
*!*	?lmain 

*!*	SELECT sum(dkp) as dkp FROM loots WHERE name = lname AND twink=.T. into CURSOR tmp
*!*	ltwink = dkp
*!*	?ltwink
*!*	?ltwink/lmain * 100