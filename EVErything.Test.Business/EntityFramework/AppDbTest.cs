using EVErything.Business.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using System;
using System.IO;

namespace EVErything.Test.Business.EntityFramework
{
    public abstract class AppDbTest
    {
        protected readonly AppDbContext ctx;
        protected readonly ILogger logger;

        public AppDbTest()
        {
            ctx = GetSqlDbContext();
            logger = CreateLogger();
        }

        private AppDbContext GetSqlDbContext()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            DbContextOptions<AppDbContext> options = builder.UseSqlServer(@"Server=B3601194\SQLEXPRESS;Database=EVErything.App.Unittest;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            AppDbContext ctx = new AppDbContext(options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            return ctx;
        }

        private ILogger CreateLogger()
        {
            string environment = "test"; // Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: false)
                .Build();

            var serviceProvider = new ServiceCollection()
                    .AddLogging(logging =>
                    {
                        logging.AddConfiguration(Configuration.GetSection("logging"));
                        logging.AddConsole();
                        logging.AddDebug();
                    })
                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>(); //.AddTrace();
            return factory.CreateLogger<AppDbTest>();
        }

        protected AppDbContext GetInMemoryDbContext()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase();
            DbContextOptions<AppDbContext> options = builder.Options;
            AppDbContext ctx = new AppDbContext(options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            return ctx;
        }
    }
}
