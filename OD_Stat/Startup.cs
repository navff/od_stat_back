using System.Diagnostics.CodeAnalysis;
using AspNet.Security.OAuth.Vkontakte;
using Common.Config;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OD_Stat.Helpings;

namespace OD_Stat
{
    using Microsoft.AspNetCore.Identity;
    using OD_Stat.DataAccess;
    using OD_Stat.Modules.Persons;
    using OD_Stat.Modules.Users;

    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<OdContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<RoleManager<Role>>();

            var authConfig = Configuration.GetSection("Authentication").Get<AuthenticationConfig>();
            
            services.AddAuthentication(v =>
                {
                    //v.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                    //v.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddGoogle(options =>
                {
                    options.ClientId = authConfig.Google.ClientId;
                    options.ClientSecret = authConfig.Google.ClientSecret;
                }) 
                .AddVkontakte(options =>
                {
                    options.ClientId = authConfig.Vk.ClientId;
                    options.ClientSecret = authConfig.Vk.ClientSecret;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,
 
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,
 
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });
                
            DiMapper.Map(services);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "OD Api V1");
                c.RoutePrefix = string.Empty;
                c.EnableDeepLinking();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}