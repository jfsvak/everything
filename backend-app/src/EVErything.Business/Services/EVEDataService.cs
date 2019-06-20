using EVErything.Business.Data;
using EVErything.Business.Models;
using EVErything.Business.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVErything.Business.Services
{
    public interface IEVEDataService
    {
        string GetEVEData(string characterID, string path);
    }

    public class EVEDataService : IEVEDataService
    {
        //private readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;
        private readonly ICacheService _cacheService;
        //private readonly UnitOfWork _unitOfWork;

        public EVEDataService(AppDbContext appDbContext, ILogger logger)
        {
            //_appDbContext = appDbContext;
            _logger = logger;
            //_unitOfWork = new UnitOfWork();
            _cacheService = new CacheService(appDbContext, logger);

        }

        public string GetEVEData(string characterID, string path)
        {
            _logger.LogTrace(characterID + " - " + path);
            if (_cacheService.HasData(characterID, path, ESISource.Singularity, false) )
            {
                _logger.LogTrace("Cache contains data for path: " + path);
                return _cacheService.GetCacheEntry(characterID, path, ESISource.Singularity).Data;
            }
            else
            {
                _logger.LogTrace("Cache doesn't contain data for path: " + path);
                return @"{}";
            }
        }
    }
}
