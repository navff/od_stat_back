using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.DaData;
using OD_Stat.Modules.Divisions;

namespace OD_Stat.Helpings
{
    [ExcludeFromCodeCoverage]
    public static class DiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            AutoMapperConfigBuilder.RegisterAutoMapper(services, new MappingProfile());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OD_Stat Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllParametersInCamelCase();
                
            });
            
            // BUSINESS SERVICES
            services.AddTransient<DivisionService>();
            services.AddTransient<DaDataService>();
            services.AddTransient<AddressService>();

            // CONTROLLERS
            services.AddTransient<DivisionsController>();
            
            // OTHERS
            services.AddDbContext<OdContext>(opt => 
                opt.UseSqlite(SqliteConfigBuilder.GetConnection()),
                ServiceLifetime.Transient);
            
        }
        
    }
}