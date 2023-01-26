using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HumanResourceApp.Repositories
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepositoryBase>
    {
        public RepositoryBase CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\HumanResource.mdf;Integrated Security=True;Connect Timeout=30").Options;

            return new RepositoryBase(options);
        }
    }
}
