using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientsWebApplication.Data;
using Microsoft.Extensions.DependencyInjection;

namespace PatientsWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }
        /**
        * @fn new CreateDbIfNotExists(host)
        * @brief CreateDbIfNotExists. This method check is Database exist. if the base does not exist, then this method creates the base and the required tables.
        * @param host is host, which has services for database
        */
        /// <summary>
        /// This does something cool.
        /// </summary>
        /// <example>
        /// Usage:
        /// @code
        ///     var = GetValueOf(9f);
        /// @endcode
        /// </example>
        /// <param name="_myParam">A float value to return</param>
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<PatientContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
