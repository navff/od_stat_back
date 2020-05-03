﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class AutoMapperConfigBuilder
    {
        public static void RegisterAutoMapper(IServiceCollection services, Profile profile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile);
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}