using Microsoft.AspNetCore.Mvc;
using PluginsHandler;
using System.Collections.Generic;
using System.Linq;

namespace ExpandableRESTApi.Controllers
{
    [ApiController]
    [Route("plugins")]
    public class PluginController : ControllerBase
    {
        public PluginController() { }

        [HttpGet, Route("get-list")]
        public IActionResult GetPluginsList()
        {
            List<string> pluginsList = PluginsService.GetPluginsList();
            return Ok(pluginsList);
        }

        [HttpGet, Route("execute/{pluginName}")]
        public IActionResult ExecutePlugin(string pluginName)
        {
            string pluginNamePascalCase = string.Join(
                "",
                pluginName.Split('-').ToList().Select(x => x.First().ToString().ToUpper() + x[1..])
            );
            string? pluginData = PluginsService.RunPlugin(pluginNamePascalCase);
            return Ok(pluginData);
        }
    }
}
