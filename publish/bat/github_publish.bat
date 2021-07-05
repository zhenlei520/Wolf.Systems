@echo off

set /p key=请输入您的秘钥:

cd ../../
dotnet restore
dotnet build
dotnet pack --configuration Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg --output nupkgs

cd nupkgs
dotnet nuget push *.nupkg -k %key%  -s https://nuget.pkg.github.com/zhenlei520/index.json --skip-duplicate
dotnet nuget push *.snupkg -k %key%  -s https://nuget.pkg.github.com/zhenlei520/index.json --skip-duplicate

echo 发布成功
pause >nul 
