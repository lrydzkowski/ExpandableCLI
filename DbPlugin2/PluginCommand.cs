using DbPlugin2.Models;
using Microsoft.EntityFrameworkCore;
using PluginBase;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbPlugin2
{
    class PluginCommand : IPluginCommand
    {
        public string? Data { get; set; } = null;

        public void Execute()
        {
            string dbFilePath = Path.Combine(
                Directory.GetParent(Assembly.GetExecutingAssembly().Location)?.FullName ?? "", "Data", "data.db"
            );
            using DbPlugin2DbContext dbContext = DbPlugin2DbContext.GetDbContext(dbFilePath);
            List<Operation> operations = dbContext.Operations
                .AsNoTracking()
                .Select(x => new Operation()
                {
                    RecId = x.RecId,
                    OperationKey = x.OperationKey
                })
                .ToList();
            var resultDataBuilder = new StringBuilder();
            operations.ForEach(operation =>
            {
                resultDataBuilder.AppendLine($"RecId: {operation.RecId}, OperationKey: {operation.OperationKey}");
            });
            Data = resultDataBuilder.ToString();
        }
    }
}
