@echo off

:Build

SET TOOLSDIR=".\.tools"
SET NUGET=".\.nuget\nuget.exe"

cls
if not exist %TOOLSDIR%\FAKE\tools\Fake.exe ( 
	%NUGET% "install" "FAKE" "-OutputDirectory" "%TOOLSDIR%" "-ExcludeVersion" "-Prerelease"
)

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%1")
  
%TOOLSDIR%"\FAKE\tools\Fake.exe" "build.fsx" "target=%TARGET%"

rem Bail if we're running a TeamCity build.
if defined TEAMCITY_PROJECT_NAME goto Quit

rem Loop the build script.
set CHOICE=nothing
echo (Q)uit, (Enter) runs the build again
set /P CHOICE= 
if /i "%CHOICE%"=="Q" goto :Quit

GOTO Build

:Quit
exit /b %errorlevel%