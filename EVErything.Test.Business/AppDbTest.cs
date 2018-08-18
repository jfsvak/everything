using EVErything.Business.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVErything.Test.Business
{
    public abstract class AppDbTest
    {
        protected readonly AppDbContext ctx;

        public AppDbTest()
        {
            ctx = GetSqlDbContext();
        }

        private AppDbContext GetSqlDbContext()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            DbContextOptions<AppDbContext> options = builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EVErything.App.Unittest;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            AppDbContext ctx = new AppDbContext(options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            return ctx;
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
