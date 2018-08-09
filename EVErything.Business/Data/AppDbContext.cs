using EVErything.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EVErything.Business.Data
{
    //public class EVErythingDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    //{
    //    public AppDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer();
        //    }
        //}
    }
}
