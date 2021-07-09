using System.Reflection;
using System.Runtime.Loader;

namespace PluginsHandler
{
    public class PluginLoadContext : AssemblyLoadContext
    {
        public PluginLoadContext(string pluginPath)
        {
            Resolver = new AssemblyDependencyResolver(pluginPath);
        }

        private AssemblyDependencyResolver Resolver { get; }

        protected override Assembly? Load(AssemblyName assemblyName)
        {
            string? assemblyPath = Resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }
    }
}
