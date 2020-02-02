using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Tests
{
    public class ServiceBuilder
    {
        private IServiceProvider  ServiceProvider { get; set; }

        public ServiceBuilder()
        {
            string[] args = new string[0]; 
            var host = CreateHostBuilder(args).Build();
            ServiceProvider = host.Services;
        }

        public T GetService<T>()
        {
            return this.ServiceProvider.GetService<T>();
        }


        private IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<TestService>();
                    services.AddTransient<InlineService>();
                });
    }
}