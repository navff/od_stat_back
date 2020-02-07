using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Cities;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OD_Stat.Helpings
{
    [ExcludeFromCodeCoverage]
    public static class DiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            AutoMapperConigBuilder.RegisterAutoMapper(services, new MappingProfile());
            services.AddTransient<ICityService, CityService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OD_Stat Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllParametersInCamelCase();
                
            });
            
            // REPOSITORIES
            
            
            // CONTROLLERS
            services.AddTransient<CityController>();
            
            // OTHERS
            services.AddDbContext<OdContext>(opt => 
                opt.UseSqlite("Data Source=od_stat.db"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();    
            
            
        }
        
    }
}