!include "nsProcess.nsh"
OutFile "Setup.exe"

installDir "$PROGRAMFILES\Swdev Bali\eMailToSMS"
!define shortcutDir "$SMPROGRAMS\eMailToSMS"
RequestExecutionLevel admin


section
	SetShellVarContext all
	setOutPath $INSTDIR
	${nsProcess::KillProcess} "SupportAlerter.exe" $R0
	ExecWait "$INSTDIR\SupportAlerterService.exe u"
	File /r "source\*"
	writeUninstaller $INSTDIR\uninstaller.exe
	CreateDirectory "${shortcutDir}" 
	createShortCut "${shortcutDir}\eMail To SMS.lnk" "$INSTDIR\SupportAlerter.exe"
	createShortCut "${shortcutDir}\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
	ExecWait "$INSTDIR\SupportAlerterService.exe i"
	Exec "$INSTDIR\SupportAlerter.exe"
sectionEnd

section "Uninstall"
	SetShellVarContext all
	ExecWait "$INSTDIR\SupportAlerterService.exe u"
	delete "$INSTDIR\uninstaller.exe"
	RMDir /r "$INSTDIR"
	RMDir /r "${shortcutDir}"
sectionEnd