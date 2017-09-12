@echo off

REM ======================================================================
REM This batch file configures components in an Oracle Instant Client Home
REM ======================================================================


REM **************************
REM CONFIGURE ASPNET Providers
REM **************************

:asp.net

REM echo Please wait... configuring Oracle Providers for ASP.NET

echo **************************************** >> install.log
echo Configuring Oracle Providers for ASP.NET >> install.log
echo **************************************** >> install.log

REM Check if .NET Framework exists
if EXIST "%SystemRoot%"\Microsoft.NET\Framework\v2.0.50727\*.* (

REM Enter the aspnet provider assembly in the GAC
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Oracle.Web.dll" >> install.log

REM Enter the aspnet provider publisher policy in the GAC
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\PublisherPolicy\2.x\Policy.2.111.Oracle.Web.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\PublisherPolicy\2.x\Policy.2.112.Oracle.Web.dll" >> install.log

REM Configure machine.config for Oracle Providers for ASP.NET
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:config /product:aspnet /frameworkversion:v2.0.50727 /productversion:2.112.3.0 /component:all >> install.log


REM ********************************************************
REM OPTIONAL SETUP - LANGUAGE SPECIFIC ASP.NET RESOURCE DLLS
REM ********************************************************

REM Enter the ASP.NET resource assemblies in the GAC
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\zh-CHS\Oracle.Web.resources.dll" >> install.log

)

echo.>> install.log
echo *************************************** >> install.log
echo Oracle Providers for ASP.NET configured >> install.log
echo *************************************** >> install.log
echo.>> install.log


REM ****************************
REM CONFIGURE ASPNET Providers 4
REM ****************************

:asp.net4

REM echo Please wait... configuring Oracle Providers for ASP.NET 4

echo ****************************************** >> install.log
echo Configuring Oracle Providers for ASP.NET 4 >> install.log
echo ****************************************** >> install.log

REM Check if .NET Framework exists
if EXIST "%SystemRoot%"\Microsoft.NET\Framework\v4.0.30319\*.* (

REM Enter the aspnet4 provider assembly in the GAC
"%BAT_DIR%"asp.net\bin\4\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\4\Oracle.Web.dll" >> install.log

REM Enter the aspnet provider publisher policy in the GAC
"%BAT_DIR%"asp.net\bin\4\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\PublisherPolicy\4\Policy.4.112.Oracle.Web.dll" >> install.log

REM Configure machine.config for Oracle Providers for ASP.NET4
"%BAT_DIR%"asp.net\bin\4\OraProvCfg.exe /action:config /product:aspnet /frameworkversion:v4.0.30319 /productversion:4.112.3.0 /component:all >> install.log


REM **********************************************************
REM OPTIONAL SETUP - LANGUAGE SPECIFIC ASP.NET 4 RESOURCE DLLS
REM **********************************************************

REM Enter the ASP.NET 4 resource assemblies in the GAC
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\de\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\es\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\fr\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\it\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\ja\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\ko\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\pt-BR\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\zh-CHS\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\zh-CHT\Oracle.Web.resources.dll" >> install.log

)

echo.>> install.log
echo ***************************************** >> install.log
echo Oracle Providers for ASP.NET 4 configured >> install.log
echo ***************************************** >> install.log
echo.>> install.log

REM echo Oracle Providers for ASP.NET 4 configured in an Oracle Instant Client Home.




REM *********************
REM CONFIGURE ODP.NET 2.0
REM *********************

:odp.net20

REM echo Please wait... configuring Oracle Data Provider for .NET 2.0

echo ********************************************* >> install.log
echo Configuring Oracle Data Provider for .NET 2.0 >> install.log
echo ********************************************* >> install.log

REM Check if .NET Framework exists
if EXIST "%SystemRoot%"\Microsoft.NET\Framework\v2.0.50727\*.* (

REM Enter the odp 2.x assembly in the GAC
"%BAT_DIR%"odp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%odp.net\bin\2.x\Oracle.DataAccess.dll" >> install.log

REM Enter the odp 2.x publisher policy in the GAC
"%BAT_DIR%"odp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%odp.net\PublisherPolicy\2.x\Policy.2.102.Oracle.DataAccess.dll" >> install.log
"%BAT_DIR%"odp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%odp.net\PublisherPolicy\2.x\Policy.2.111.Oracle.DataAccess.dll" >> install.log
"%BAT_DIR%"odp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%odp.net\PublisherPolicy\2.x\Policy.2.112.Oracle.DataAccess.dll" >> install.log


REM configure machine.config for Framework 2.x with proper section handler
"%BAT_DIR%"odp.net\bin\2.x\OraProvCfg.exe /action:config /product:odp /frameworkversion:v2.0.50727 /providerpath:"%BAT_DIR%odp.net\bin\2.x\Oracle.DataAccess.dll" >> install.log

REM register the counters
"%BAT_DIR%"odp.net\bin\2.x\OraProvCfg.exe /action:register /product:odp /component:perfcounter /providerpath:"%BAT_DIR%odp.net\bin\2.x\Oracle.DataAccess.dll" >> install.log

REM ********************************************************
REM OPTIONAL SETUP - LANGUAGE SPECIFIC ODP.NET RESOURCE DLLS
REM ********************************************************

REM Enter the ODP.NET 2.x resource assemblies in the GAC
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\de\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\es\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\fr\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\it\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\ja\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\ko\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\pt-BR\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\zh-CHS\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\zh-CHT\Oracle.Web.resources.dll" >> install.log

)

REM setup registry entries for ODP.NET 2.x
echo Windows Registry Editor Version 5.00                                     >  "%BAT_DIR%"\odp.net.reg
echo [HKEY_LOCAL_MACHINE\SOFTWARE\%ODAC_CFG_PREFIX%Oracle\ODP.NET]            >> "%BAT_DIR%"\odp.net.reg
echo [HKEY_LOCAL_MACHINE\SOFTWARE\%ODAC_CFG_PREFIX%Oracle\ODP.NET\2.112.3.0]  >> "%BAT_DIR%"\odp.net.reg
echo "DllPath"="%REG_DIR%bin"                                                 >> "%BAT_DIR%"\odp.net.reg
echo "PromotableTransaction"="promotable"                                     >> "%BAT_DIR%"\odp.net.reg
echo "StatementCacheWithUdts"="1"                                             >> "%BAT_DIR%"\odp.net.reg
echo "TraceFileName"="c:\\odpnet2.trc"                                        >> "%BAT_DIR%"\odp.net.reg
echo "TraceLevel"="0"                                                         >> "%BAT_DIR%"\odp.net.reg
echo "TraceOption"="0"                                                        >> "%BAT_DIR%"\odp.net.reg
echo "PerformanceCounters"="0"                                                >> "%BAT_DIR%"\odp.net.reg
echo "UdtCacheSize"="4096"                                                    >> "%BAT_DIR%"\odp.net.reg
echo "DemandOraclePermission"="0"                                             >> "%BAT_DIR%"\odp.net.reg
echo "SelfTuning"="1"                                                         >> "%BAT_DIR%"\odp.net.reg
echo "MaxStatementCacheSize"="100"                                            >> "%BAT_DIR%"\odp.net.reg

regedit /s "%BAT_DIR%\odp.net.reg"
del /q "%BAT_DIR%\odp.net.reg"



REM *******************
REM CONFIGURE ODP.NET 4
REM *******************

:odp.net4

REM echo Please wait... configuring Oracle Data Provider for .NET 4

echo ******************************************* >> install.log
echo Configuring Oracle Data Provider for .NET 4 >> install.log
echo ******************************************* >> install.log

REM Check if .NET Framework exists
if EXIST "%SystemRoot%"\Microsoft.NET\Framework\v4.0.30319\*.* (

REM Enter the odp 4 assembly in the GAC
"%BAT_DIR%"odp.net\bin\4\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%odp.net\bin\4\Oracle.DataAccess.dll" >> install.log

REM Enter the odp 4 publisher policy in the GAC
"%BAT_DIR%"odp.net\bin\4\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%odp.net\PublisherPolicy\4\Policy.4.112.Oracle.DataAccess.dll" >> install.log

REM configure machine.config for Framework 4 with proper section handler
"%BAT_DIR%"odp.net\bin\4\OraProvCfg.exe /action:config /product:odp /frameworkversion:v4.0.30319 /providerpath:"%BAT_DIR%odp.net\bin\4\Oracle.DataAccess.dll" >> install.log

REM register the counters
"%BAT_DIR%"odp.net\bin\4\OraProvCfg.exe /action:register /product:odp /component:perfcounter /providerpath:"%BAT_DIR%odp.net\bin\4\Oracle.DataAccess.dll" >> install.log


REM **********************************************************
REM OPTIONAL SETUP - LANGUAGE SPECIFIC ODP.NET 4 RESOURCE DLLS
REM **********************************************************

REM Enter the ODP.NET 4 resource assemblies in the GAC
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\de\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\es\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\fr\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\it\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\ja\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\ko\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\pt-BR\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\zh-CHS\Oracle.Web.resources.dll" >> install.log
"%BAT_DIR%"asp.net\bin\2.x\OraProvCfg.exe /action:gac /providerpath:"%BAT_DIR%asp.net\bin\2.x\Resources\zh-CHT\Oracle.Web.resources.dll" >> install.log

)

REM setup registry entries for ODP.NET 4
echo Windows Registry Editor Version 5.00                                     >  "%BAT_DIR%"\odp.net.reg
echo [HKEY_LOCAL_MACHINE\SOFTWARE\%ODAC_CFG_PREFIX%Oracle\ODP.NET]            >> "%BAT_DIR%"\odp.net.reg
echo [HKEY_LOCAL_MACHINE\SOFTWARE\%ODAC_CFG_PREFIX%Oracle\ODP.NET\4.112.3.0]  >> "%BAT_DIR%"\odp.net.reg
echo "DllPath"="%REG_DIR%bin"                                                 >> "%BAT_DIR%"\odp.net.reg
echo "PromotableTransaction"="promotable"                                     >> "%BAT_DIR%"\odp.net.reg
echo "StatementCacheWithUdts"="1"                                             >> "%BAT_DIR%"\odp.net.reg
echo "TraceFileName"="c:\\odpnet4.trc"                                        >> "%BAT_DIR%"\odp.net.reg
echo "TraceLevel"="0"                                                         >> "%BAT_DIR%"\odp.net.reg
echo "TraceOption"="0"                                                        >> "%BAT_DIR%"\odp.net.reg
echo "PerformanceCounters"="0"                                                >> "%BAT_DIR%"\odp.net.reg
echo "UdtCacheSize"="4096"                                                    >> "%BAT_DIR%"\odp.net.reg
echo "DemandOraclePermission"="0"                                             >> "%BAT_DIR%"\odp.net.reg
echo "SelfTuning"="1"                                                         >> "%BAT_DIR%"\odp.net.reg
echo "MaxStatementCacheSize"="100"                                            >> "%BAT_DIR%"\odp.net.reg

regedit /s "%BAT_DIR%\odp.net.reg"
del /q "%BAT_DIR%\odp.net.reg"


echo.>> install.log
echo ****************************************** >> install.log
echo Oracle Data Provider for .NET 4 configured >> install.log
echo ****************************************** >> install.log
echo.>> install.log
REM echo Oracle Data Provider for .NET configured in an Oracle Instant Client Home.

pause
exit

