using DbPlugin1.Models;
using Microsoft.EntityFrameworkCore;
using PluginBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DbPlugin1
{
    class PluginCommand : IPluginCommand
    {
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
            users.ForEach(user =>
            {
                Console.WriteLine($"UserId: {user.UserId}, Login: {user.Login}, Email: {user.Email}");
            });
            Console.WriteLine();
        }
    }
}
