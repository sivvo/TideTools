SELECT names
nFile = FCREATE("c:\nameimp.txt")
SCAN

lcname = name
lnlevel = level
lcclass = class

lcstring = 'insert into tide_names (name, level, class) values ("'+;
			ALLTRIM(lcName)+'", '+ALLTRIM(STR(lnLevel))+', "'+ALLTRIM(lcclass)+'");'
FPUTS(nFile, lcString)

ENDSCAN

FCLOSE(nfile)