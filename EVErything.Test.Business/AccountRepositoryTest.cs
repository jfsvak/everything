using EVErything.Business;
using EVErything.Business.Data;
using EVErything.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace EVErything.Test.Business
{
    public class AccountRepositoryTest
    {
        [Fact]
        public void Add_WhenNotExists()
        {
            var ctx = GetInMemoryDbContext();
            var accountRepo = new Repository<Account>(ctx);
            var characterRepo = new Repository<Character>(ctx);
            var characterSetRepo = new Repository<CharacterSet>(ctx);

            Account acc = accountRepo.Insert(new Account
            {
                ID = new System.Guid(),
                Name = "Acc1"
            });

            CharacterSet characterSet = characterSetRepo.Insert(new CharacterSet
            {
                ID = new System.Guid(),
            });

            Character char1 = characterRepo.Insert(new Character
            {
                Name = "Mulvi",
                ID = "12345678",
                Account = acc,
                CharacterSet = characterSet                
            });

            accountRepo.SaveChanges();

            Assert.Single(accountRepo.Get().ToList());
            Assert.Single(characterRepo.Get().ToList());
            Assert.Single(characterSetRepo.Get().ToList());
            Assert.Equal("Acc1", acc.Name);
            
        }

        private AppDbContext GetInMemoryDbContext()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase();
            DbContextOptions<AppDbContext> options = builder.Options;
            AppDbContext ctx = new AppDbContext(options);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            return ctx;
        }

        private Repository<Account> GetInMemoryAccountepository()
        {
            return new Repository<Account>(this.GetInMemoryDbContext());
        }
    }
}
