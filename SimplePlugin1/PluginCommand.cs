using PluginBase;
using System.Text;

namespace SimplePlugin1
{
    public class PluginCommand : IPluginCommand
    {
        public string? Data { get; set; } = null;

        public void Execute()
        {
            StringBuilder resultDataBuilder = new();
            resultDataBuilder.AppendLine("Run from SimplePlugin1.");
            Data = resultDataBuilder.ToString();
        }
    }
}
