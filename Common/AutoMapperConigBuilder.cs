using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class AutoMapperConigBuilder
    {
        public static void RegisterAutoMapper(IServiceCollection services, Profile profile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile);
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}