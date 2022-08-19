using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.DAL.Data;

namespace Talabat
{
    public class Program
    {
        public static  async  Task Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var LoggerFactory=services.GetRequiredService<ILoggerFactory>();

            try
            {
               var context = services.GetRequiredService<StoreContext>();

                await context.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(context, LoggerFactory);
            }

            catch (Exception ex)
            {
                var Logger=LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex,"An erorr Ocuured" );

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
