using EVErything.Business.Data;
using EVErything.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace EVErything.Test.Business.EntityFramework
{
    public class CharacterFlowTest : AppDbTest
    {
        [Fact]
        public void Add_CharactherFlow()
        {
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
    }
}
