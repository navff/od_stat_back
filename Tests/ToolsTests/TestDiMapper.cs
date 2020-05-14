using System.IO;
using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OD_Stat.DataAccess;
using OD_Stat.Helpings;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.DaData;
using OD_Stat.Modules.Divisions;
using Tests.SimpleTestClasses;

namespace Tests.ToolsTests
{
    public static class TestDiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            AutoMapperConfigBuilder.RegisterAutoMapper(services, new MappingProfile());

            // Test services
            services.AddTransient<TestService>();
            services.AddTransient<InlineService>();

            var configuration = ConfigHelper.GetIConfigurationRoot(Directory.GetCurrentDirectory());
            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<DivisionService>();
            services.AddTransient<AddressService>();
            services.AddTransient<DaDataService>();

            // CONTROLLERS
            services.AddTransient<DivisionsController>();
            
            // OTHERS
            
            services.AddDbContext<OdContext>(options => 
                    options.UseSqlite(SqliteConfigBuilder.GetConnection()),
                    ServiceLifetime.Transient);
        }
    }
}