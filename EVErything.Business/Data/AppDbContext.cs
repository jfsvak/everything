using EVErything.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace EVErything.Business.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
    }
}
