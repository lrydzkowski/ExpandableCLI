using PluginBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PluginsHandler
{
    public static class PluginsService
    {
        public static string PluginsDirPath { get; } = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory ?? "./", "Plugins"
        );

        public static List<string> GetPluginsList()
        {
            List<string> pluginNames = Directory.GetDirectories(PluginsDirPath)
                .Select(pluginDirPath => Path.GetFileName(pluginDirPath))
                .Where(pluginName => GetPluginCommand(pluginName) != null)
                .ToList();
            return pluginNames;
        }

        public static IPluginCommand? GetPluginCommand(string pluginName)
        {
            string pluginFilePath = Path.Combine(PluginsDirPath, pluginName, $"{pluginName}.dll");
            if (!File.Exists(pluginFilePath))
            {
                return null;
            }
            var loadContext = new PluginLoadContext(pluginFilePath);
            IPluginCommand? pluginCommand = loadContext.LoadFromAssemblyName(new AssemblyName(pluginName))
                .GetTypes()
                .Where(type => typeof(IPluginCommand).IsAssignableFrom(type) && !type.IsAbstract)
                .Select(type => (IPluginCommand?)Activator.CreateInstance(type))
                .OfType<IPluginCommand>()
                .FirstOrDefault();
            return pluginCommand;
        }

        public static void RunPlugin(string pluginName)
        {
            IPluginCommand? pluginCommand = GetPluginCommand(pluginName);
            if (pluginCommand == null)
            {
                return;
            }
            pluginCommand.Execute();
        }
    }
}
