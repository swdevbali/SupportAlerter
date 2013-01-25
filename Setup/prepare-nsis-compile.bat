@echo off
copy "..\SupportAlerter\bin\release\SupportAlerter.exe"
copy "..\SupportAlerter\bin\release\OpenPop.dll"
copy "..\SupportAlerter\bin\release\SupportAlerterLibrary.dll"
mkdir icon
copy "..\SupportAlerter\bin\release\icon\sms-32.ico" "icon\"
mkdir database
copy "..\SupportAlerter\bin\release\Database\AccountDatabase.sdf" "Database\"
copy "..\SupportAlerterService\bin\release\SupportAlerterService.exe"
copy "..\SupportAlerterService\bin\release\InstallUtil.exe"

