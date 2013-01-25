OutFile "Setup.exe"

installDir "$PROGRAMFILES\Swdev Bali\eMailToSMS"
!define shortcutDir "$SMPROGRAMS\eMailToSMS"
RequestExecutionLevel admin


section
	SetShellVarContext all
	setOutPath $INSTDIR
	File OpenPop.dll
	File SupportAlerter.exe
	File SupportAlerterLibrary.dll
	File database\*
	File icon\*
	File SupportAlerterService.exe
	File InstallUtil.exe
	writeUninstaller $INSTDIR\uninstaller.exe
	CreateDirectory "${shortcutDir}" 
	createShortCut "${shortcutDir}\eMail To SMS.lnk" "$INSTDIR\SupportAlerter.exe"
	createShortCut "${shortcutDir}\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
sectionEnd

	section "Uninstall"
	SetShellVarContext all
	delete "$INSTDIR\uninstaller.exe"
	RMDir /r "$INSTDIR"
	RMDir /r "${shortcutDir}"
sectionEnd