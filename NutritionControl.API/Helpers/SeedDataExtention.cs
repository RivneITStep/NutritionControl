using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NutritionControl.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionControl.API.Helpers
{
    public static class SeedData
    {
        public static IWebHost SeedDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                try
                {
                    var initializer = scope
                        .ServiceProvider
                        .GetRequiredService<IEntityInitializer>();

                    initializer.SeedData().Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return webHost;
        }
    }
}