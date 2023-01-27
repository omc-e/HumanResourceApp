using HumanResourceApp.Model;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceApp.Repositories
{
    public class RepositoryBase : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<ZaposleniciModel> Zaposlenici { get; set; }
        public DbSet<DogadjajiModel> Dogadjaji { get; set; }

        public RepositoryBase()
        {
        }
        public RepositoryBase(DbContextOptions options) : base(options)
        {
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\HumanResource.mdf;Integrated Security=True;Connect Timeout=30");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DogadjajiModel>()
                .HasOne(d => d.Zaposlenici)
                .WithMany(z => z.Dogadjaji)
                .HasForeignKey(d => d.ZaposleniciId);
        }

    }
}
