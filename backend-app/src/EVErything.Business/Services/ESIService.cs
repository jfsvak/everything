using System;
using System.Collections.Generic;
using System.Text;

namespace EVErything.Business.Services
{
    /// <summary>
    /// Handles communication with ESI Server (EVE Swagger Interface)
    /// </summary>
    public class ESIService
    {
        public string Get(string charID, string path)
        {
            return @"{ ""charisma"": 20, ""intelligence"": 20, ""memory"": 20, ""perception"": 20, ""willpower"": 20}";
        }
    }
}
