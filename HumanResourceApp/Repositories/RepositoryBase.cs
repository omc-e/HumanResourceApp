using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using HumanResourceApp.Model;

namespace HumanResourceApp.Repositories
{
    public  class RepositoryBase : DbContext
    {
        public DbSet<UserModel> User { get; set; }

        public RepositoryBase()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\HumanResource.mdf;Integrated Security=True;Connect Timeout=30");
        }

    }
}
