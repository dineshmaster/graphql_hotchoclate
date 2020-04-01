using Cinema.Model.CoreData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cinema.Model.RepositoryCore
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        CinemaDbContext cinemaDbContext;
        DbSet<TEntity> dbSet;
        public GenericRepository(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.dbSet = cinemaDbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            cinemaDbContext.Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToBeDeleted = cinemaDbContext.Find<TEntity>(id);
            Delete(entityToBeDeleted);
        }

        public void Delete(TEntity entityToBeDeleted)
        {
            cinemaDbContext.Remove(entityToBeDeleted);
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> predicate = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            // filtering the objects
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // Adding includeProperties
            foreach(var property in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            // Ordering the objects
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        public void Update(TEntity entityToBeUpdated)
        {
            dbSet.Attach(entityToBeUpdated);
            cinemaDbContext.Entry(entityToBeUpdated).State = EntityState.Modified;
        }
    }
}
