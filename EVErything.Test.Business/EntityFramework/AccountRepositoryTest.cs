using EVErything.Business.Models;
using EVErything.Business.Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EVErything.Test.Business.EntityFramework
{
    public class AccountRepositoryTest : AppDbTest
    {
        [Fact]
        public void Add_CharactersNormalFlow()
        {
            // Create Character and new set
            var char1111 = ctx.Characters.Add(new Character
            {
                ID = "1111",
                Name = "Main Spai 1",
                CharacterSet = new CharacterSet()
            }).Entity;
            ctx.SaveChanges();

            // Set char as main character
            char1111.CharacterSet.MainCharacter = char1111;
            ctx.SaveChanges();

            var char1111DB = ctx.Characters.Single(c => c.ID == "1111");
            Assert.Equal("Main Spai 1", char1111DB.Name);

            // Create 2nd character under same CharacterSer
            ctx.Characters.Add(new Character { ID = "2222", Name = "Spai 2", CharacterSet = char1111DB.CharacterSet });
            ctx.SaveChanges();

            var char2222DB = ctx.Characters.Single(c => c.ID == "2222");
            Assert.Equal("Spai 2", char2222DB.Name);

            // Get all the characters in the set
            var charsInSet = ctx.Characters.Where(c => c.CharacterSetID == char2222DB.CharacterSetID).ToList();
            Assert.NotEmpty(charsInSet);
            Assert.Equal(2, charsInSet.Count());

            // Create account with the chars
            var spaiAccount = ctx.Accounts.Add(new Account
            {
                Name = "All The Spais",
                Characters = new List<Character> { char1111DB, char2222DB }
            }).Entity;
            ctx.SaveChanges();

            var spais = ctx.Characters.Where(c => c.AccountID == spaiAccount.ID).ToList();
            Assert.NotEmpty(spais);
            Assert.Equal(2, spais.Count());

            var spaisInSet = ctx.Characters.Where(c => c.CharacterSet.MainCharacterID == char1111DB.ID).ToList();
            Assert.NotEmpty(spaisInSet);
            Assert.Equal(2, spaisInSet.Count());
        }

        [Fact]
        public void Update_AccountGraph()
        {
            //var guid = System.Guid.NewGuid();
            //var charSetGuid = System.Guid.NewGuid();
            var charSet = new CharacterSet();// { ID = charSetGuid };

            Account acc = new Account
            {
                //ID = guid,
                Name = "Acc1",
                Characters = new List<Character>
                {
                    new Character { ID = "123456789", Name = "Mulvi", CharacterSet = charSet },
                    new Character { ID = "987654321", Name = "Korin", CharacterSet = charSet }
                }
            };

            var addedAccount = ctx.Accounts.Add(acc).Entity;
            ctx.SaveChanges();
            //Include(a => a.Characters).
            var accFromDB = ctx.Accounts.Single(a => a.ID == addedAccount.ID);
            //Assert.NotEmpty(accFromDB);
            Assert.NotNull(accFromDB);
            Assert.Equal("Acc1", accFromDB.Name);

            var char2222 = new Character { ID = "2222", Name = "Spai 1", CharacterSet = new CharacterSet() };
            ctx.Characters.Add(char2222);
            ctx.SaveChanges();

            char2222.CharacterSet.MainCharacter = char2222;
            ctx.SaveChanges();

            var charSetFor2222 = ctx.Characters.Single(c => c.ID == "2222").CharacterSet;
            ctx.Characters.Add(new Character { ID = "3333", Name = "Spai 2", CharacterSet = charSetFor2222});
            ctx.SaveChanges();

            var charactersFor2222 = ctx.Characters.Where(c => c.CharacterSetID == charSetFor2222.ID).ToList();
            Assert.Equal(2, charactersFor2222.Count());
        }

        [Fact]
        public void Add_WhenNotExists()
        {
            var ctx = GetInMemoryDbContext();
            var accountRepo = new Repository<Account>(ctx);
            var characterRepo = new Repository<Character>(ctx);
            var characterSetRepo = new Repository<CharacterSet>(ctx);
            var tokenRepo = new Repository<Token>(ctx);

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
                CharacterSetID = characterSet.ID
            });

            var token = tokenRepo.Insert(new Token
            {
                AccessToken = "asdf",
                RefreshToken = "qwert",
                CharacterID = char1.ID,
                TokenType = "Bearer",
                ExpiresIn = 5000
            });

            accountRepo.SaveChanges();

            Assert.Single(accountRepo.Find().ToList());
            Assert.Single(characterRepo.Find().ToList());
            Assert.Single(characterSetRepo.Find().ToList());
            Assert.Equal("Acc1", acc.Name);
            Assert.Equal("Mulvi", char1.Name);
            Assert.Equal("Mulvi", char1.Name);
        }

        private Repository<Account> GetInMemoryAccountepository()
        {
            return new Repository<Account>(this.GetInMemoryDbContext());
        }
    }
}
