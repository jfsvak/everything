using System;
using System.Collections.Generic;
using System.Text;

using EVErything.Business.Data;
using EVErything.Business.Models;
using EVErything.Business.Services;
using EVErything.Test.Business.EntityFramework;
using Xunit;
using Xunit.Abstractions;

namespace EVErything.Test.Business.Services
{
    public class CacheServiceTest : AppDbTest
    {
        private readonly ITestOutputHelper _output;

        public CacheServiceTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void Get_CacheEntry()
        {
            var newchar1111 = ctx.Characters.Add(new Character
            {
                ID = "1111",
                Name = "Main Spai 1",
                CharacterSet = new CharacterSet()
            }).Entity;
            ctx.SaveChanges();

            string data = @"{""a"":10}";
            bool updated = new CacheService(ctx).UpdateCache("1111", "characters/1111/attributes", ESISource.Singularity, data);
            _output.WriteLine("Cache was updated: [{0}]", updated);

            var entry = new CacheService(ctx).GetCacheEntry("1111", "characters/1111/attributes", ESISource.Singularity);
            _output.WriteLine("Cache entry updated [{0}]", entry.LastUpdateTimestamp);
            Assert.Equal(data, entry.Data);
        }
    }
}
