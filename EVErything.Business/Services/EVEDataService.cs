using EVErything.Business.Data;
using EVErything.Business.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVErything.Business.Services
{
    public class EVEDataService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;

        public EVEDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public EVEDataService(AppDbContext appDbContext, ILogger<EVEDataService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public string GetEVEData(string characterID, string path)
        {

            return @"{""i"":10}";
        }
    }
}
