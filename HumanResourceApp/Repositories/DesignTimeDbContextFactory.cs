using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
