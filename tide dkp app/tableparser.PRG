

AFIELDS(arTable)

lclist = ""

FOR i = 1 TO ALEN(arTable, 1)

	lcfield = artable[i,1]
	lctype  = artable[i,2]
	lnwidth = artable[i,3]
	
	lcStr = ", "+ ALLTRIM(lcField) +" "+ALLTRIM(lcType)+"("+ALLTRIM(STR(lnWidth)) +")"

	lcList = lcList+lcStr
ENDFOR
lcList = SUBSTR(lcList,2)
nfile = FCREATE("c:\tablesql.txt")
FPUTS(nFile, lcList)
FCLOSE(nFile)