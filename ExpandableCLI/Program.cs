using PluginsHandler;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace ExpandableCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    args = new string[] { "-h" };
                }
                RootCommand rootCommand = DefineAvailableCommands();
                new CommandLineBuilder(rootCommand)
                    .UseDefaults()
                    .UseExceptionHandler(HandleException)
                    .Build()
                    .Invoke(args);
            }
            catch (Exception ex)
            {
                View.ShowError(ex);
            }
            Console.ReadLine();
        }

        private static RootCommand DefineAvailableCommands()
        {
            RootCommand rootCommand = new();
            rootCommand.Description = "Application which presents an idea of expandability by plugins.";

            Command pluginsCommand = new("plugins");
            pluginsCommand.Description = "Functionalities connected with plugins.";
            rootCommand.Add(pluginsCommand);

            Command listCommand = new("list");
            listCommand.Description = "Shows list of available plugins.";
            listCommand.Handler = CommandHandler.Create(ShowPluginsList);
            pluginsCommand.Add(listCommand);

            Command runCommand = new("run");
            runCommand.Description = "Run plugin's functionality.";
            runCommand.AddOption(new Option<string>(
                aliases: new[] { "--plugin-name", "-n" },
                description: "Name of plugin",
                getDefaultValue: () => "DbPlugin1"
            ));
            runCommand.Handler = CommandHandler.Create<string>(RunPlugin);
            pluginsCommand.Add(runCommand);

            return rootCommand;
        }

        private static void ShowPluginsList()
        {
            Console.WriteLine("Plugins names:");
            List<string> plugins = PluginsService.GetPluginsList();
            if (plugins.Count == 0)
            {
                Console.WriteLine("No plugins");
            }
            else
            {
                plugins.ForEach(pluginName => Console.WriteLine($"  {pluginName}"));
            }
        }

        private static void RunPlugin(string pluginName)
        {
            string? pluginData = PluginsService.RunPlugin(pluginName);
            if (pluginData == null)
            {
                Console.WriteLine("Plugin doesn't exist.");
                return;
            }
            Console.WriteLine($"Run plugin {pluginName}:");
            Console.WriteLine(pluginData);
        }

        private static void HandleException(Exception ex, InvocationContext invocationContext)
        {
            HandleException(ex);
        }

        private static void HandleException(Exception ex)
        {
            View.ShowError(ex);
        }
    }
}
