using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Cities;

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