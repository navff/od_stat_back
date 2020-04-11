using Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OD_Stat.DataAccess;
using OD_Stat.Helpings;
using OD_Stat.Modules.Divisions;

namespace Tests
{
    public static class TestDiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            services.AddTransient<TestService>();
            services.AddTransient<InlineService>();
            services.AddTransient<DivisionService>();
            
            // CONTROLLERS
            services.AddTransient<DivisionsController>();
            
            // OTHERS
            
            services.AddDbContext<OdContext>(options => 
                    options.UseSqlite(SqliteConfigBuilder.GetConnection()),
                    ServiceLifetime.Transient);
            
            AutoMapperConigBuilder.RegisterAutoMapper(services, new MappingProfile());
        }
    }
}