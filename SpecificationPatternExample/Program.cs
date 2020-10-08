using System;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SpecificationPatternExample.ConfigSection;
using SpecificationPatternExample.Data;

namespace SpecificationPatternExample
{
    public class Program
    {
        public const string STARTUP_PROJECT_NAME = "SpecificationPatternExample";
        private static ILogger<Program> _logger;

        public static void Main(string[] args)
        {
            _logger = LoggerFactory.Create(builder => builder.AddConsole())
                                   .CreateLogger<Program>();

            try
            {
                using IHost host = BuildHost(args);

                _logger.LogInformation($"{STARTUP_PROJECT_NAME} Migration starting");

                RunMigration();

                _logger.LogInformation($"{STARTUP_PROJECT_NAME} Migration finished");

                _logger.LogInformation($"{STARTUP_PROJECT_NAME} is run");
                host.Run();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
            }
            finally
            {
                _logger.LogInformation($"{STARTUP_PROJECT_NAME} is shutting down");
            }
        }

        private static void RunMigration()
        {
            var tryCount = 0;
            migrate:
            try
            {
                tryCount++;
                using (DataContext dataContext = new DataContextDesignTime().CreateDbContext(null!))
                {
                    _logger.LogInformation($"Db Migration attempt number : {tryCount}");
                    dataContext.Database.Migrate();
                }
            }
            catch (Exception)
            {
                if (tryCount < 3)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    goto migrate;
                }

                throw;
            }
        }

        private static IHost BuildHost(string[] args)
        {
            IHost webHost = GetHostBuilder(args).Build();
            return webHost;
        }

        private static IHostBuilder GetHostBuilder(string[] args)
        {
            string[] urls = AppConfigs.AppUrls();

            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
                                           .ConfigureWebHostDefaults(webBuilder =>
                                                                     {
                                                                         webBuilder.UseStartup<Startup>()
                                                                                   .ConfigureAppConfiguration((hostingContext, config) => { AppConfigs.PrepareConfig(config); })
                                                                                   .ConfigureLogging((host, logging) =>
                                                                                                     {
                                                                                                         logging.ClearProviders();
                                                                                                         logging.AddConsole();
                                                                                                     })
                                                                                   .UseUrls(urls)
                                                                             ;
                                                                     });

            return hostBuilder;
        }
    }
}