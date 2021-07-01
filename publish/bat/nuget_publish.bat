@echo off

set /p key=������������Կ:

cd ../../
dotnet restore
dotnet build
dotnet pack --configuration Release -p:IncludeSymbols=true --output nupkgs

cd nupkgs
dotnet nuget push *.nupkg -k %key%  -s https://api.nuget.org/v3/index.json --skip-duplicate
dotnet nuget push *.snupkg -k %key%  -s https://api.nuget.org/v3/index.json --skip-duplicate

echo �����ɹ�
pause >nul 