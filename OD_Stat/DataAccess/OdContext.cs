using Microsoft.EntityFrameworkCore;
using OD_Stat.Modules.Divisions;
using OD_Stat.Modules.Geo.Addresses;

namespace OD_Stat.DataAccess
{
    public class OdContext : DbContext
    {
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public OdContext(DbContextOptions<OdContext> options)
            : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}