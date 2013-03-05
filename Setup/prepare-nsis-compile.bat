@echo off
del source\*.* /S /F /Q
mkdir source
copy "..\SupportAlerter\bin\release\SupportAlerter.exe" source
copy "..\SupportAlerter\bin\release\OpenPop.dll" source
copy "..\SupportAlerter\bin\release\SupportAlerterLibrary.dll" source
mkdir source\icon
copy "..\SupportAlerter\bin\release\icon\sms-32.ico" "source\icon\" 
copy "..\SupportAlerterService\bin\release\SupportAlerterService.exe" source

