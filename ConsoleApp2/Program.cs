using System;
using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp2
{
    public class Program
    {
        public const string ENV_VARIABLE = "ASPNETCORE_ENVIRONMENT";
        public static IConfigurationRoot Configuration;
        public static ILoggerFactory LoggerFactory;

        public static void Main(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable(ENV_VARIABLE);

            if (String.IsNullOrEmpty(environment))
                throw new ArgumentException("Environment not found in [" + ENV_VARIABLE + "]");

            Console.WriteLine("Environment: {0}", environment);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);

            builder.AddJsonFile($"appsettings.{environment}.json", optional: false);

            Configuration = builder.Build();

            var services = new ServiceCollection()
                .AddLogging(logging =>
                {
                    logging.AddConfiguration(Configuration.GetSection("logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                });

            Console.WriteLine($"Configuration successfully loaded from: appsettings.{environment}.json");
            services.AddScoped<ILoggerFactory, LoggerFactory>();
            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("console2app.Main");

            logger.LogDebug("Main: Hello World in Debug");
            logger.LogTrace("Main: Hello World in Trace");

            LogSomething(serviceProvider.GetRequiredService<ILoggerFactory>());

            //services.AddTransient<ILogger, >
        }

        public static void LogSomething(ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("console2app.LogSomething");
            logger.LogDebug("Hello World in Debug");
            logger.LogTrace("Hello World in Trace");

        }
    }
}
