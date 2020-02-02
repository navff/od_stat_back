using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Tests
{
    public class ConfigBuilder
    {
        public void Run()
        {
            string[] args = new string[0]; 
            var host = CreateHostBuilder(args).Build();
            var testService = host.Services.GetService<TestService>();
            var result = testService.Invoke();
            if (testService == null) return;
        }

        
        
        /*
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }); */

        public IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<TestService>();
                });
    }
}