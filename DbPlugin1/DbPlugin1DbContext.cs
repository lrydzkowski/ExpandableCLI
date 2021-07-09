using DbPlugin1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DbPlugin1
{
    class DbPlugin1DbContext : DbContext
    {
        public DbPlugin1DbContext(DbContextOptions<DbPlugin1DbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static DbPlugin1DbContext GetDbContext(string dbFilePath)
        {
            var builder = new DbContextOptionsBuilder<DbPlugin1DbContext>();
            builder.UseSqlite($"Data Source={dbFilePath}");
            return new DbPlugin1DbContext(builder.Options);
        }
    }
}
