using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NutritionControl.API.Helpers;

namespace NutritionControl.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().SeedDatabase().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}