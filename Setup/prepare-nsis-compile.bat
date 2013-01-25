@echo off
mkdir source
copy "..\SupportAlerter\bin\release\SupportAlerter.exe" source
copy "..\SupportAlerter\bin\release\OpenPop.dll" source
copy "..\SupportAlerter\bin\release\SupportAlerterLibrary.dll" source
mkdir source\icon
copy "..\SupportAlerter\bin\release\icon\sms-32.ico" "source\icon\" 
mkdir source\database
copy "..\SupportAlerter\bin\release\Database\AccountDatabase.sdf" "source\Database\"
copy "..\SupportAlerterService\bin\release\SupportAlerterService.exe" source
copy "..\SupportAlerterService\bin\release\InstallUtil.exe" source

