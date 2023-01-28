using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HumanResourceApp.Repositories
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepositoryBase>
    {
        public RepositoryBase CreateDbContext(string[] args)
        {
           

            return new RepositoryBase();
        }
    }
}
