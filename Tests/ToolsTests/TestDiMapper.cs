using Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OD_Stat.DataAccess;
using OD_Stat.Helpings;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Cities;
using OD_Stat.Modules.Geo.Countries;

namespace Tests
{
    public static class TestDiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            services.AddTransient<TestService>();
            services.AddTransient<InlineService>();
            services.AddTransient<ICityService, CityService>();
            
            // REPOSITORIES
            services.AddTransient<IUnitOfWork, UnitOfWork>();    
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<CountryRepository>();
            
            // CONTROLLERS
            services.AddTransient<CityController>();
            
            // OTHERS
            
            services.AddDbContext<OdContext>(options => 
                    options.UseSqlite(SqliteConfigBuilder.GetConnection()),
                    ServiceLifetime.Transient);
            
            AutoMapperConigBuilder.RegisterAutoMapper(services, new MappingProfile());
        }
    }
}