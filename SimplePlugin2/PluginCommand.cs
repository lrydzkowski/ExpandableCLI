using PluginBase;
using System.Text;

namespace SimplePlugin2
{
    public class PluginCommand : IPluginCommand
    {
        public string? Data { get; set; } = null;

        public void Execute()
        {
            StringBuilder resultDataBuilder = new();
            resultDataBuilder.AppendLine("Run from SimplePlugin2.");
            Data = resultDataBuilder.ToString();
        }
    }
}
