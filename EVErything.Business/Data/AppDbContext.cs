using EVErything.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EVErything.Business.Data
{
    //public class EVErythingDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    //{
    //    public AppDbContext CreateDbContext(string[] args)
    //    {
    //        Console.WriteLine("args: " + args);
    //        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    //        Console.WriteLine("env: " + env);
    //        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        return new AppDbContext(optionsBuilder.Options);
    //    }
    //}

    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSet> CharacterSets { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public AppDbContext() : base()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Character>().OwnsOne(c => c.Token).ToTable("Tokens");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("optionsBuilder.IsConfigured: " + optionsBuilder.IsConfigured);

            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer();
            //}
        }
    }
}
