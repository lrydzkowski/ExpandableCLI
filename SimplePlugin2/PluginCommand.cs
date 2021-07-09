using PluginBase;
using System;

namespace SimplePlugin2
{
    public class PluginCommand : IPluginCommand
    {
        public void Execute()
        {
            Console.WriteLine("Run from SimplePlugin2.");
            Console.WriteLine();
        }
    }
}
