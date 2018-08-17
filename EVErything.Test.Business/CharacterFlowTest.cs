using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EVErything.Test.Business
{
    public class CharacterFlowTest
    {
        private AppDbContext ctx;

        public CharacterFlowTest()
        {
            ctx = GetSqlDbContext();
        }

        [Fact]
        public void Add_CharactherFlow()
        {

        }
    }
}
