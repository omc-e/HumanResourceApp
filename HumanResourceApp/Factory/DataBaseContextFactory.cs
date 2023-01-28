using HumanResourceApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceApp.Factory
{
    public class DataBaseContextFactory
    {
        private readonly string _connectionString;
        public DataBaseContextFactory(string cString)
        {
            _connectionString = cString;
        }

        public RepositoryBase CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;

            return new RepositoryBase();
        }
    }

}

