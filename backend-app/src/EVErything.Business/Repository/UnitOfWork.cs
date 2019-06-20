using EVErything.Business.Data;
using EVErything.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVErything.Business.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context;
        private Repository<ESIDataCache> esiDataCacheRepository;
        private Repository<Character> characterRepository;
        public bool disposed = false;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }


        public Repository<ESIDataCache> ESIDataCacheRepository
        {
            get
            {
                if (this.esiDataCacheRepository == null)
                {
                    this.esiDataCacheRepository = new Repository<ESIDataCache>(_context);
                }

                return esiDataCacheRepository;
            }
        }

        public Repository<Character> CharacterRepository
        {
            get
            {
                if (this.characterRepository == null)
                {
                    this.characterRepository = new Repository<Character>(_context);
                }

                return characterRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
