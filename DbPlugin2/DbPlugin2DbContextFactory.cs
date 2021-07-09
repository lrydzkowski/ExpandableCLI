using Microsoft.EntityFrameworkCore.Design;

namespace DbPlugin2
{
    class DbPlugin2DbContextFactory : IDesignTimeDbContextFactory<DbPlugin2DbContext>
    {
        public DbPlugin2DbContext CreateDbContext(string[] args)
        {
            return DbPlugin2DbContext.GetDbContext(@".\Data\data.db");
        }
    }
}
