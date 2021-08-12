@echo off

:: this script needs https://www.nuget.org/packages/ilmerge

:: set your target executable name (typically [projectname].exe)
SET APP_NAME=Reviser.exe

:: Set build, used for directory. Typically Release or Debug
SET ILMERGE_BUILD=Release

:: set your NuGet ILMerge Version, this is the number from the package manager install, for example:
:: PM> Install-Package ilmerge -Version 3.0.29
:: to confirm it is installed for a given project, see the packages.config file
SET ILMERGE_VERSION=3.0.41

:: the full ILMerge should be found here:
SET ILMERGE_PATH=%USERPROFILE%\.nuget\packages\ilmerge\%ILMERGE_VERSION%\tools\net452

echo Merging %APP_NAME%...

:: add project DLL's starting with replacing the FirstLib with this project's DLL
"%ILMERGE_PATH%"\ILMerge.exe ^
  /ndebug:false ^
  /target:winexe ^
  /targetplatform:v4 ^
  /lib:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2" ^
  /ndebug:false ^
  /out:"..\%APP_NAME%" ^
  "Reviser.exe" ^
  "Newtonsoft.Json.dll" ^
  "Ookii.Dialogs.WinForms.dll"

:Done
echo Merged %APP_NAME%.
