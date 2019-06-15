using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using EVErything.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace EVErything.Web.Data
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .Property(r => r.LockoutEnabled)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<ApplicationUser>()
                .Property(r => r.EmailConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<ApplicationUser>()
                .Property(r => r.TwoFactorEnabled)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            builder.Entity<ApplicationUser>()
                .Property(r => r.PhoneNumberConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
