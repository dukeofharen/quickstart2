$configuration = (Get-Childitem env:CONFIGURATION).Value
Rename-Item "Ducode.QS2\bin\$configuration\Ducode.QS2.exe" quickstart2.exe
Rename-Item "Ducode.QS2\bin\$configuration\Ducode.QS2.exe.config" App.config

Get-Childitem . -recurse -include *.xml -force | Remove-Item
Get-Childitem . -recurse -include *.pdb -force | Remove-Item