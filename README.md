# ExpandableCLI

A simple solution created in Visual Studio 2019 presenting implementations of plugins in .NET Core applications (C#).
ExpandableCLI solution is composed of the following projects:

Common libraries:

- **PluginBase** - .NET Core 3.1 library with an interface which has to be implemented by classes allowing to run
plugin functionalities.
- **PluginsHandler** - .NET Core 3.1 library with mechanisms relating to work with plugins. It offers such 
functionalities like getting list of available plugins and running a plugin.

Plugins:

- **DbPlugin1** - .NET 5 library. Code which connects to SQLite database in order to show data from it. It uses Entity
Framework Core 5:
  - Microsoft.EntityFrameworkCore.Sqlite (5.0.7)
  - Microsoft.EntityFrameworkCore.Tools (5.0.7)
- **DbPlugin2** - .NET Core 3.1 library. Code which connects to SQLite database in order to show data from it. It uses
Entity Framework Core 3.1:
  - Microsoft.EntityFrameworkCore.Sqlite (3.1.16)
  - Microsoft.EntityFrameworkCore.Tools (3.1.16)
- **SimplePlugin1** - .NET 5 library. Simple code showing a message in console.
- **SimplePlugin2** - .NET 5 library. Simple code showing a message in console.

Applications using plugins:

- **ExpandableCLI** - .NET 5 console application presenting plugins functionality. It uses dynamically loaded
plugins which are mentioned above.
- **ExpandableRESTApi** - .NET 5 ASP.NET Web API appliaction presenting plugins functionality. It uses dynamically 
loaded plugins which are mentioned above.

## How to use?

You have to run one of the following commands in PowerShell:

```powershell
.\ExpandableCLI.exe plugins list
.\ExpandableCLI.exe plugins run --plugin-name DbPlugin1
.\ExpandableCLI.exe plugins run --plugin-name SimplePlugin1
```