using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests
{
    public static class TestDiMapper
    {
        public static void Map(IServiceCollection services)
        {
            // SERVICES
            services.AddTransient<TestService>();
            services.AddTransient<InlineService>();
            
            // REPOSITORIES
            services.AddTransient<IUnitOfWork, UnitOfWork>();    
            
            // CONTROLLERS
            services.AddTransient<GeoController>();
            
            // OTHERS
            services.AddDbContext<OdContext>(opt => 
                opt.UseInMemoryDatabase("ODStat"));
        }
    }
}