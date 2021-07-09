using Microsoft.EntityFrameworkCore.Design;

namespace DbPlugin1
{
    class DbPlugin1DbContextFactory : IDesignTimeDbContextFactory<DbPlugin1DbContext>
    {
        public DbPlugin1DbContext CreateDbContext(string[] args)
        {
            return DbPlugin1DbContext.GetDbContext(@".\Data\data.db");
        }
    }
}
