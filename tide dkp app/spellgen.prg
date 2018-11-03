SELECT spells
nFile = FCREATE("c:\eqspells.txt")

SCAN

lcName = ALLTRIM(name)
lcdesc1 = ALLTRIM(Desc1)
lcdesc2 = ALLTRIM(Desc2)
lcdesc3 = ALLTRIM(Desc3)
lcdesc4 = ALLTRIM(Desc4)
lcdesc5 = ALLTRIM(Desc5)
lcdesc6 = ALLTRIM(Desc6)
lcdesc7 = ALLTRIM(Desc7)
lcdesc8 = ALLTRIM(Desc8)
lcdesc9 = ALLTRIM(Desc9)
lcdesc10 = ALLTRIM(Desc10)
lcdesc11 = ALLTRIM(Desc11)
lcdesc12 = ALLTRIM(Desc12)

lcDesc = ""
lcDesc = IIF(!EMPTY(lcDesc1), lcDesc+lcDesc1, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc2), lcDesc+[ - ]+lcDesc2, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc3), lcDesc+[ - ]+lcDesc3, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc4), lcDesc+[ - ]+lcDesc4, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc5), lcDesc+[ - ]+lcDesc5, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc6), lcDesc+[ - ]+lcDesc6, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc7), lcDesc+[ - ]+lcDesc7, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc8), lcDesc+[ - ]+lcDesc8, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc9), lcDesc+[ - ]+lcDesc9, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc10), lcDesc+[ - ]+lcDesc10, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc11), lcDesc+[ - ]+lcDesc11, lcDesc)
lcDesc = IIF(!EMPTY(lcDesc12), lcDesc+[ - ]+lcDesc12, lcDesc)

*lcDesc 1-12
lndescount = 0
lcMana = ALLTRIM(manacost)
IF lcMana # "0"
	lcMana = IIF(!EMPTY(ALLTRIM(lcMana)), "Mana: "+ALLTRIM(lcMana), "")	
ELSE
	lcMana = ""
ENDIF

lcRecast = ALLTRIM(recasttime)
IF lcRecast # "0"
	lcRecast = IIF(!EMPTY(ALLTRIM(recasttime)), "Recast: "+ALLTRIM(recasttime), "")
ELSE
	lcRecast = ""
ENDIF

lcResist = IIF(!EMPTY(ALLTRIM(resist)), "Resist: "+ALLTRIM(resist), "")
lcRange1 = IIF(!EMPTY(ALLTRIM(range)), "Range: "+ALLTRIM(range), "")
lcRange2 = IIF(!EMPTY(ALLTRIM(aerange)), "Range: "+ALLTRIM(aerange), "")

lcInteruptable = ALLTRIM(uninterruptable)
IF lcInteruptable="1"
	lcInteruptable = "Interupt: Yes"
ELSE
	lcInteruptable = ""
ENDIF
		
lcTargetType = IIF(!EMPTY(ALLTRIM(targettype)), "Target: "+ALLTRIM(targettype), "")
*lcCategory = "Category: "+ALLTRIM(category)

lcCastTime = ALLTRIM(castingtime)
IF lcCastTime # "0"
	lcCastTime = IIF(!EMPTY(ALLTRIM(castingtime)), "Cast Time: "+ALLTRIM(castingtime), "")
ELSE
	lcCastTime = ""
ENDIF

*lcFizzleTime = "Fizzle Time: "+ALLTRIM(fizzletime)
lcResistAdjust = ALLTRIM(resistadj)
IF lcResistAdjust # "0"
	lcResistAdjust = IIF(!EMPTY(ALLTRIM(resistadj)), "Resist Adj: "+ALLTRIM(resistadj), "")
ELSE
	lcResistAdjust = ""
ENDIF

*lcDispellable = "Dispellable: "+ALLTRIM(nodispell)

lcSpellType = IIF(!EMPTY(ALLTRIM(spelltype)), "Type: "+ALLTRIM(spelltype), "")


lcClasses = ALLTRIM(classes)
IF lcClasses # "None"
	lcclasses = IIF(!EMPTY(ALLTRIM(classes)), "Classes: "+ALLTRIM(classes), "")
ELSE
	lcClasses = ""
ENDIF

*lcDuration = IIF(!EMPTY(ALLTRIM(duration)), "Duration: "+ALLTRIM(duration ), "")

lcDurationText = IIF(!EMPTY(ALLTRIM(durationtext)), "Duration "+ALLTRIM(durationtext), "")
lcyou = IIF(!EMPTY(ALLTRIM(castmsg3)), "Text: "+ALLTRIM(castmsg3), "")
lcother = IIF(!EMPTY(ALLTRIM(castmsg4)), "Other: "+ALLTRIM(castmsg4), "")
lcfades = IIF(!EMPTY(ALLTRIM(castmsg5)), "Fades: "+ALLTRIM(castmsg5), "")


IF OCCURS("0", lcRange2) < 1
	lcRange = lcRange2
ELSE
	lcRange = lcRange1
ENDIF
&&bene lcRange = lcRange1
&&Detrimental lcRange = lcRange2

*castmsg3 = on
*castmsg4 = other
*castmsg5 = off
lcstr = lcname+[ ]+lcDesc+[ ];
+lcresist+[ ];
+lcresistadjust+[ ];
+lcrange+[ ];
+lcrecast+[ ];
+lctargettype+[ ];
+lcdurationtext+[ ];
+lcMana+[ ];
+lccasttime+[ ];
+lcspelltype+[ ];
+lcinteruptable+[ ];
+lcclasses+[ ];
+lcyou+[ ];
+lcfades
lcStr=ALLTRIM(lcStr)
lcStr = STRTRAN(lcStr, "   ", "  ")
lcStr = STRTRAN(lcStr, "  ", " ")
lcStr = STRTRAN(lcStr, "--", "- ")
lcStr = STRTRAN(lcStr, "- -", "- ")
lcStr = STRTRAN(lcStr, "  ", " ")
IF RIGHT(lcStr,1) = "-"
	lcStr = SUBSTR(lcStr,1,LEN(lcStr)-1)
ENDIF
FPUTS(nFile, lcStr)
ENDSCAN
FCLOSE(nFile)	