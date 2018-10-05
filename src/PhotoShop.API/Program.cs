using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoShop.Core.Interfaces;
using PhotoShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder();

            if(args.Contains("ci"))
                builder.ConfigureAppConfiguration((builderContext, config) =>
                 {
                     config
                     .AddInMemoryCollection(new Dictionary<string, string>
                     {
                         { "isCI", "true"}
                     });
                 });

            var host = builder.Build();

            ProcessDbCommands(args, host);

            host.Run();            
        }
        
        public static IWebHostBuilder CreateWebHostBuilder() =>
            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>();

        private static void ProcessDbCommands(string[] args, IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var dateTime = scope.ServiceProvider.GetRequiredService<IDateTime>();


                if (args.Contains("ci"))
                    args = new string[4] { "dropdb", "migratedb", "seeddb", "stop" };

                if (args.Contains("dropdb"))
                    context.Database.EnsureDeleted();

                if (args.Contains("migratedb"))
                    context.Database.Migrate();

                if (args.Contains("seeddb"))
                {
                    context.Database.EnsureCreated();
                    var eventStore = scope.ServiceProvider.GetRequiredService<IEventStore>();
                    var repository = scope.ServiceProvider.GetRequiredService<IRepository>();
                    AppInitializer.Seed(dateTime, eventStore, services, repository);
                }               
            }
        }        
    }
}
