using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.Divisions;
using OD_Stat.Modules.Persons;

namespace OD_Stat.DataAccess
{
    public sealed class OdContext : DbContext
    {
        static object locker = new object();
        
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        
        public OdContext(DbContextOptions<OdContext> options)
            : base(options)
        {
            lock (locker)
            {
                Database.Migrate();
            }
        }

        private bool HasUnappliedMigrations()
        {
            var migrationsAssembly = this.GetService<IMigrationsAssembly>();
            var differ = this.GetService<IMigrationsModelDiffer>();

            return differ.HasDifferences(
                migrationsAssembly.ModelSnapshot.Model,
                this.Model);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}