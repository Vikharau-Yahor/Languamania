#User defined variables
$SQLServer = "(local)"

#-------------------------------------------------------------------------------------------
#Update logic
#-------------------------------------------------------------------------------------------

$curFolder = Get-Location
$sqlFolder = ($curFolder.Path).Replace(".local\sql","Languamania.Data\sql\")
$sqlFiles = Get-ChildItem -Path ($sqlFolder + "*.sql")

foreach ($sqlFile in $sqlFiles)
{
  Invoke-Sqlcmd -ServerInstance $SQLServer -InputFile $sqlFile.FullName
  Write-Host "Executing script: " + $sqlFile.Name
}

Write-Host "DB Update finished."