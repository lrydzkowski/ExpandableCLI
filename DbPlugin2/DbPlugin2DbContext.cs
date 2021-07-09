using DbPlugin2.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DbPlugin2
{
    class DbPlugin2DbContext : DbContext
    {
        public DbPlugin2DbContext(DbContextOptions<DbPlugin2DbContext> options) : base(options) { }

        public DbSet<Operation> Operations => Set<Operation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static DbPlugin2DbContext GetDbContext(string dbFilePath)
        {
            var builder = new DbContextOptionsBuilder<DbPlugin2DbContext>();
            builder.UseSqlite($"Data Source={dbFilePath}");
            return new DbPlugin2DbContext(builder.Options);
        }
    }
}
