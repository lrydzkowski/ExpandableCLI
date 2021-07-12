#
# Script responsible for moving compiled SimplePlugin1 library to a subdirectory of ExpandableCLI console app.
# It is required for loading SimplePlugin1 by ExpandableCLI app. 
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
    $pluginName = "SimplePlugin1";
    $pluginDestinationDirPath = "${solutionDirPath}${consumerAppName}\bin\${configurationName}\net5.0\Plugins\${pluginName}";
    if (!(Test-Path -Path $pluginDestinationDirPath))
    {
        New-Item -Path $pluginDestinationDirPath -ItemType "directory" | Out-Null
    }
    Copy-Item -Path "${compilationDirPath}*.dll" -Destination $pluginDestinationDirPath -Exclude "PluginBase.dll"
}