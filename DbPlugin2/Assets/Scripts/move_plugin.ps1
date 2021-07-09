#
# Script responsible for moving compiled DbPlugin2 library to a subdirectory of ExpandableCLI console app.
# It is required for loading DbPlugin2 by ExpandableCLI app. 
# Script is run on post-build event.
#

param(
    [Parameter(Mandatory)]
    [string]$solutionDirPath,
    [Parameter(Mandatory)]
    [string]$compilationDirPath,
    [Parameter(Mandatory)]
    [string]$configurationName
)

$consumerAppName = "ExpandableCLI";
$pluginName = "DbPlugin2";
$pluginDestinationDirPath = "${solutionDirPath}${consumerAppName}\bin\${configurationName}\net5.0\Plugins\${pluginName}";
if (!(Test-Path -Path $pluginDestinationDirPath))
{
    New-Item -Path $pluginDestinationDirPath -ItemType "directory" | Out-Null
}
Copy-Item -Path "${compilationDirPath}*.dll" -Destination $pluginDestinationDirPath -Exclude "PluginBase.dll"
Copy-Item   -Path "${solutionDirPath}${pluginName}\Assets\SQLite\win-x64\native\e_sqlite3.dll" `
            -Destination $pluginDestinationDirPath

$dbDataDirPath = "${pluginDestinationDirPath}\Data";
if (!(Test-Path -Path $dbDataDirPath))
{
    New-Item -Path $dbDataDirPath -ItemType "directory" | Out-Null
}
Copy-Item -Path "${solutionDirPath}${pluginName}\Data\data.db" -Destination "${dbDataDirPath}\data.db"