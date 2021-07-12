using DbPlugin1.Models;
using Microsoft.EntityFrameworkCore;
using PluginBase;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DbPlugin1
{
    class PluginCommand : IPluginCommand
    {
        public string? Data { get; set; } = null;

        public void Execute()
        {
            string dbFilePath = Path.Combine(
                Directory.GetParent(Assembly.GetExecutingAssembly().Location)?.FullName ?? "", "Data", "data.db"
            );
            using DbPlugin1DbContext dbContext = DbPlugin1DbContext.GetDbContext(dbFilePath);
            List<User> users = dbContext.Users
                .AsNoTracking()
                .Select(x => new User()
                {
                    UserId = x.UserId,
                    Login = x.Login,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();
            StringBuilder resultDataBuilder = new();
            users.ForEach(user =>
            {
                resultDataBuilder.AppendLine($"UserId: {user.UserId}, Login: {user.Login}, Email: {user.Email}");
            });
            Data = resultDataBuilder.ToString();
        }
    }
}
