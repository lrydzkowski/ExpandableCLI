using PluginBase;
using System;

namespace SimplePlugin1
{
    public class PluginCommand : IPluginCommand
    {
        public void Execute()
        {
            Console.WriteLine("Run from SimplePlugin1.");
            Console.WriteLine();
        }
    }
}
