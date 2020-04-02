using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model.RepositoryCore
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        /// <summary>
        /// Gets the objects with condition and orderby
        /// </summary>
        /// <param name="predicate">Condition on the objects</param>
        /// <param name="orderBy">Order by parameter</param>
        /// <param name="includeProperties">Properties to be include while retrieving</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity,bool>> predicate = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy =  null,
            string includeProperties = "");
        /// <summary>
        /// Get object by id
        /// </summary>
        /// <param name="id">ID of the object to be retrieved</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(object id);
        /// <summary>
        /// Add entity to the dbset
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        void Add(TEntity entity);
        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id">ID of the object to be deleted</param>
        void Delete(object id);
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entityToBeDeleted">Entity to be deleted</param>
        void Delete(TEntity entityToBeDeleted);
        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entityToBeUpdated">Entity to be updated</param>
        void Update(TEntity entityToBeUpdated);
    }
}
