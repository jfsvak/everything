using EVErything.Business.Data;
using EVErything.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVErything.Business.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context = new AppDbContext();
        private Repository<ESIDataCache> esiDataCacheRepository;
        private Repository<Character> characterRepository;
        public bool disposed = false;

        public Repository<ESIDataCache> ESIDataCacheRepository
        {
            get
            {
                if (this.esiDataCacheRepository == null)
                {
                    this.esiDataCacheRepository = new Repository<ESIDataCache>(context);
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
                    this.characterRepository = new Repository<Character>(context);
                }

                return characterRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
