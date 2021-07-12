#
# Script responsible for moving compiled DbPlugin1 library to a subdirectory of ExpandableCLI console app.
# It is required for loading DbPlugin1 by ExpandableCLI app. 
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

$consumerAppNames = $("ExpandableCLI", "ExpandableRESTApi");
Foreach ($consumerAppName in $consumerAppNames)
{
    $pluginName = "DbPlugin1";
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
}