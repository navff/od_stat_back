using Microsoft.EntityFrameworkCore;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Cities;
using OD_Stat.Modules.Geo.Countries;
using OD_Stat.Modules.Geo.Regions;

namespace OD_Stat.DataAccess
{
    public class OdContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        
        public OdContext(DbContextOptions<OdContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}