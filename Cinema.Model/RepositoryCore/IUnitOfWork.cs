using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model.RepositoryCore
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Cinema.Model.Entity.Cinema> cinemaRepository { get; }
        /// <summary>
        /// Commit the changes to database
        /// </summary>
        Task CommitAsync();

    }
}
