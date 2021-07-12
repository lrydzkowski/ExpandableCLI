namespace PluginBase
{
    public interface IPluginCommand
    {
        public string? Data { get; set; }

        public void Execute();
    }
}
