using Microsoft.EntityFrameworkCore;
using System;

namespace GTR.Repository.Logic.Repositories.Base
{
    public class BaseRepository<TUnitOfWork, TEntity>
     where TEntity : class
     where TUnitOfWork : DbContext
    {
        private bool _disposed = false;
        private readonly IUnitOfWork _unitOfWork;
        protected const string ASC = "asc";

        public TUnitOfWork Context
        {
            get
            {
                return (TUnitOfWork)_unitOfWork;
            }
        }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentException("UnitOfWork not set");
            _unitOfWork = unitOfWork;
        }

        public virtual DbSet<TEntity> GetDbSet()
        {
            return Context.Set<TEntity>();
        }

        #region Dispose

        ~BaseRepository()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && Context != null)
                {
                    Context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}