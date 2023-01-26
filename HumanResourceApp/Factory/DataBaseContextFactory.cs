using HumanResourceApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return new RepositoryBase(options);
        }
    }

}

