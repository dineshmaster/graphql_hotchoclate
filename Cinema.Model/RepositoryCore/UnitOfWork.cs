using Cinema.Model.CoreData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Model.RepositoryCore
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private readonly CinemaDbContext cinemaDbContext;
        public UnitOfWork(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }
        public IGenericRepository<Cinema.Model.Entity.Cinema> cinemaRepository 
            => new GenericRepository<Cinema.Model.Entity.Cinema>(cinemaDbContext);

        public void CommitAsync()
        {
            this.cinemaDbContext.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.cinemaDbContext.DisposeAsync();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
