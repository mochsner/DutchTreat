using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting; //<-- Here it is
using DutchTreat.Data;

namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            SeedDb(host);

            host.Run();
        }
        
        private static void SeedDb(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                // Same as hosting.services.getservice, but in context of scope
                var seeder = scope.ServiceProvider.GetService<DutchSeeder>(); 
                
                seeder.Seed();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        /* NOTE: Config ASP.NET Core is different than ASP.NET
         * It doesn't use web.config (strictly json), but configuration in code for flexibility
         */
        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            // Removing the default config options
            builder.Sources.Clear();

            // Overwriting Occurs for configuration here (bottom is priority)
            builder.AddJsonFile("config.json", false, true)
                   .AddEnvironmentVariables();

            //hrow new NotImplementedException();
        }

    }
}
