using DbPlugin2.Models;
using Microsoft.EntityFrameworkCore;
using PluginBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DbPlugin2
{
    class PluginCommand : IPluginCommand
    {
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
            operations.ForEach(operation =>
            {
                Console.WriteLine($"RecId: {operation.RecId}, OperationKey: {operation.OperationKey}");
            });
            Console.WriteLine();
        }
    }
}
