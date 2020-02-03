using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Tests
{
    public class DIServiceBuilder
    {
        private IServiceProvider  ServiceProvider { get; set; }

        public DIServiceBuilder()
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
                    TestDiMapper.Map(services);
                });
    }
}