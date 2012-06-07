REM *** Sample with case 440x280x290
rmdir /s /q .\Output1
mkdir .\Output1
..\Bin\TreeDim.StackBuilder.XmlFileProcessor.exe /i ".\Input1.xml"

REM *** Sample with bundle
rmdir /s /q .\Output2
mkdir .\Output2
..\Bin\TreeDim.StackBuilder.XmlFileProcessor.exe /i ".\Input2.xml"

PAUSE