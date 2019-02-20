using EVErything.Business.Services;
using EVErything.Test.Business.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EVErything.Test.Business.Services
{
    public class ESIServiceTest : AppDbTest
    {
        public void Get_ESIData()
        {
            string attributes = new EVEDataService(ctx).GetEVEData("1111", "/characters/1111/attributes");
            Assert.Equal("", attributes);
        }
    }
}
