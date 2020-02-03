using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace OD_Stat.Helpings
{
    public static class DiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            AutoMapperConigBuilder.RegisterAutoMapper(services, new MappingProfile());

            // REPOSITORIES
            
            
            // CONTROLLERS
            services.AddTransient<GeoController>();
            
            // OTHERS
            services.AddDbContext<OdContext>(opt => 
                opt.UseInMemoryDatabase("ODStat"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();    
            
            
        }
        
    }
}