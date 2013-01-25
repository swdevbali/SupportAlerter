!include "nsProcess.nsh"
OutFile "Setup.exe"

installDir "$PROGRAMFILES\Swdev Bali\eMailToSMS"
!define shortcutDir "$SMPROGRAMS\eMailToSMS"
RequestExecutionLevel admin


section
	SetShellVarContext all
	setOutPath $INSTDIR
	${nsProcess::KillProcess} "SupportAlerter.exe" $R0
	ExecWait "$INSTDIR\InstallUtil.exe /u SupportAlerterService.exe"
	File /r "source\*"
	writeUninstaller $INSTDIR\uninstaller.exe
	CreateDirectory "${shortcutDir}" 
	createShortCut "${shortcutDir}\eMail To SMS.lnk" "$INSTDIR\SupportAlerter.exe"
	createShortCut "${shortcutDir}\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
	ExecWait "$INSTDIR\InstallUtil.exe SupportAlerterService.exe"
	
sectionEnd

	section "Uninstall"
	SetShellVarContext all
	delete "$INSTDIR\uninstaller.exe"
	RMDir /r "$INSTDIR"
	RMDir /r "${shortcutDir}"
sectionEnd