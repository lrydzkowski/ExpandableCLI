#
# Script responsible for moving compiled SimplePlugin2 library to a subdirectory of ExpandableCLI console app.
# It is required for loading SimplePlugin2 by ExpandableCLI app. 
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
$pluginName = "SimplePlugin2";
$pluginDestinationDirPath = "${solutionDirPath}${consumerAppName}\bin\${configurationName}\net5.0\Plugins\${pluginName}";
if (!(Test-Path -Path $pluginDestinationDirPath))
{
    New-Item -Path $pluginDestinationDirPath -ItemType "directory" | Out-Null
}
Copy-Item -Path "${compilationDirPath}*.dll" -Destination $pluginDestinationDirPath -Exclude "PluginBase.dll"