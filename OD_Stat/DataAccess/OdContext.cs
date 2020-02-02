using Microsoft.EntityFrameworkCore;
using OD_Stat.Modules.Geo;

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
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}