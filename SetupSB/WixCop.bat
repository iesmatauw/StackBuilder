@ECHO OFF
echo Call WixCop to make a cleaner wxs code
"C:\Program Files (x86)\WiX Toolset v3.7\bin\WixCop.exe" /f /s ..\SetupSB\*.wxs
"C:\Program Files (x86)\WiX Toolset v3.7\bin\WixCop.exe" /f /s ..\MergeModuleSB\*.wxs
"C:\Program Files (x86)\WiX Toolset v3.7\bin\WixCop.exe" /f /s ..\StackBuilderGUIExtMSM\*.wxs
pause