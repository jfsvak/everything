using EVErything.Business;
using EVErything.Business.Data;
using EVErything.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EVErything.Test.Business.EntityFramework
{
    public class ESIDataCacheTest : AppDbTest
    {

        /// <summary>
        /// Use scenarios:
        /// - Add data to cache
        /// - find by character id and
        ///     - ESIRoute
        ///     - ESISource
        ///     - 
        /// - Update data for an entry
        /// </summary>

        [Fact]
        public void Add_ESIDataCacheEntry()
        {
            // Create Character and new set
            var newchar1111 = ctx.Characters.Add(new Character
            {
                ID = "1111",
                Name = "Main Spai 1",
                CharacterSet = new CharacterSet()
            }).Entity;
            ctx.SaveChanges();

            //var yall = ctx.Characters.Single(c => c.ID == "1111");
            var char1111 = ctx.Characters.Find("1111");
            Console.WriteLine("Name : [" + char1111.Name + "]");
            var cachedAttributes = ctx.ESIDataCaches.Add(new ESIDataCache
            {
                Character = char1111,
                ESIRoute = "/characters/1111/attributes",
                ESISource = "singularity",
                LastUpdateTimestamp = DateTime.Now,
                Data = @"{ ""charisma"": 20, ""intelligence"": 20, ""memory"": 20, ""perception"": 20, ""willpower"": 20}"
            }).Entity;

            ctx.SaveChanges();

            // Get all the characters in the set
            //var chars = ctx.Characters.Where(c => c.CharacterSetID == char2222DB.CharacterSetID).ToList();
            //Assert.Equal(2, charsInSet.Count());
        }

        [Fact]
        public void Update_ESIDataCacheEntry()
        {
            // Create character
            var newchar1111 = ctx.Characters.Add(new Character
            {
                ID = "1111",
                Name = "Main Spai 1",
                CharacterSet = new CharacterSet()
            }).Entity;
            ctx.SaveChanges();

            var char1111 = ctx.Characters.Find("1111");

            // Create first entry in cache
            var cachedAttributes = ctx.ESIDataCaches.Add(new ESIDataCache
            {
                Character = char1111,
                ESIRoute = "/characters/1111/attributes",
                ESISource = "singularity",
                LastUpdateTimestamp = DateTime.Now,
                Data = @"{ ""charisma"": 20, ""intelligence"": 20, ""memory"": 20, ""perception"": 20, ""willpower"": 20 }"
            }).Entity;

            ctx.SaveChanges();


            // update cache entry
            cachedAttributes.Data = @"{ ""charisma"": 27, ""intelligence"": 19, ""memory"": 24, ""perception"": 23, ""willpower"": 22 }";
            cachedAttributes.LastUpdateTimestamp = DateTime.Now;
            ctx.ESIDataCaches.Update(cachedAttributes);

            ctx.SaveChanges();
        }

        [Fact]
        public void FindAndUpdate_ESIDataCacheEntry()
        {
            // Create character
            var newchar1111 = ctx.Characters.Add(new Character
            {
                ID = "1111",
                Name = "Main Spai 1",
                CharacterSet = new CharacterSet()
            }).Entity;
            ctx.SaveChanges();

            var char1111 = ctx.Characters.Find("1111");

            // Create first entry in cache
            var cachedAttributes = ctx.ESIDataCaches.Add(new ESIDataCache
            {
                Character = char1111,
                ESIRoute = "/characters/1111/attributes",
                ESISource = "singularity",
                LastUpdateTimestamp = DateTime.Now,
                Data = @"{ ""charisma"": 20, ""intelligence"": 20, ""memory"": 20, ""perception"": 20, ""willpower"": 20 }"
            }).Entity;

            ctx.SaveChanges();

            IEnumerable<ESIDataCache> foundCacheEntries = from data in ctx.ESIDataCaches
                                                          where data.ESIRoute == "/characters/1111/attributes"
                                                            && data.CharacterID == "1111"
                                                          select data
                                                          ;
                                                          //Where(d => d.ESIRoute.Equals("/characters/1111/attributes")).ToList();

            // update cache entry
            //foundCacheEntry.Data = @"{ ""charisma"": 27, ""intelligence"": 19, ""memory"": 24, ""perception"": 23, ""willpower"": 22 }";
            //foundCacheEntry.LastUpdateTimestamp = DateTime.Now;
            ctx.ESIDataCaches.Update(cachedAttributes);

            ctx.SaveChanges();

        }

        private Repository<Account> GetInMemoryAccountepository()
        {
            return new Repository<Account>(this.GetInMemoryDbContext());
        }
    }
}
