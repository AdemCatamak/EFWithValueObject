using System;
using System.Threading.Tasks;
using EFWithValueObject.Api.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFWithValueObject.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (IHost host = CreateHostBuilder(args).Build())
            {
                using (IServiceScope serviceScope = host.Services.CreateScope())
                {
                    IServiceProvider serviceProvider = serviceScope.ServiceProvider;
                    var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();
                    await appDbContext.Database.MigrateAsync();
                }

                await host.RunAsync();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}