﻿using System;
using System.Linq;
using System.Collections.Generic;

using EVErything.Business.Data;
using EVErything.Business.Models;
using EVErything.Business.Repository;

namespace EVErything.Business.Services
{
    public enum ESISource { Tranquility, Singularity, Duality };

    public class CacheService
    {
        private UnitOfWork unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        public CacheService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Constructor to allow this instance of the service to participate in an external UnitOfWork, 
        /// e.g. shared between multiple services
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CacheService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Checks to see if the cache contains the data and/or if it needs updating based on the parameter
        /// </summary>
        /// <param name="considerExpiry">true if cache expiry should be considered, false if not</param>
        /// <returns>true if the cache contains the data or it needs updating based on checkForUpdate</returns>
        public bool HasData(string characterID, string route, ESISource source, bool considerExpiry)
        {
            return _getCacheEntries(characterID, route, source).Any();
        }

        /// <summary>
        /// Gets data from the cache. Gets the one with the latest update timestamp
        /// </summary>
        /// <param name="characterID"></param>
        /// <param name="route"></param>
        /// <param name="source"></param>
        /// <returns>Data from the cache</returns>
        public ESIDataCache GetCacheEntry(string characterID, string route, ESISource source)
        {
            return _getCacheEntries(characterID, route, source).OrderByDescending(c => c.LastUpdateTimestamp).First();
        }

        /// <summary>
        /// Updates the cache. Returns true if the cache was updated, false if it wasn't
        /// </summary>
        /// <param name="characterID"></param>
        /// <param name="route"></param>
        /// <param name="source"></param>
        /// <param name="data"></param>
        /// <returns>true if the cache was updated, false if it wasn't</returns>
        public bool UpdateCacheEntry(string characterID, string route, ESISource source, string data)
        {
            if (!HasData(characterID, route, source, false))
            {
                var character = unitOfWork.CharacterRepository.GetByID(characterID);

                var entryToUpdate = unitOfWork.ESIDataCacheRepository.Insert(new ESIDataCache
                {
                    Character = character,
                    ESIRoute = route,
                    ESISource = Enum.GetName(typeof(ESISource), source),
                    LastUpdateTimestamp = DateTime.Now,
                    Data = data
                });
            }
            else
            {
                var entryToUpdate = this._getCacheEntries(characterID, route, source).OrderByDescending(c => c.LastUpdateTimestamp).First();

                entryToUpdate.Data = data;
                entryToUpdate.LastUpdateTimestamp = DateTime.Now;
            }

            unitOfWork.Save();

            return true;
        }

        /// <summary>
        /// Deletes the cache entry
        /// </summary>
        /// <param name="characterID"></param>
        /// <param name="route"></param>
        /// <param name="source"></param>
        /// <returns>true if the cache was deleted, false if it wasn't</returns>
        public bool DeleteCacheEntry(string characterID, string route, string source)
        {

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterID"></param>
        /// <param name="route"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private IEnumerable<ESIDataCache> _getCacheEntries(string characterID, string route, ESISource source)
        {
            return _getCacheEntries(source).Where(c => c.ESIRoute == route && c.CharacterID == characterID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private IEnumerable<ESIDataCache> _getCacheEntries(ESISource source)
        {
            return unitOfWork.ESIDataCacheRepository.Find(d => d.ESISource == Enum.GetName(typeof(ESISource), source));
        }
    }
}
