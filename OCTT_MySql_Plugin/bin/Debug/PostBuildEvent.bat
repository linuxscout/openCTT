@echo off
copy e:\NETWork\NET_1\OpenCTTSolution\OCTT_MySql_Plugin\bin\Debug\OCTT_MySql_Plugin.dll e:\NETWork\NET_1\OpenCTTSolution\\OpenCTT\bin\Release
copy e:\NETWork\NET_1\OpenCTTSolution\OCTT_MySql_Plugin\bin\Debug\OCTT_MySql_Plugin.dll e:\NETWork\NET_1\OpenCTTSolution\\OpenCTT\bin\Debug
if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd