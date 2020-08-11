namespace JobBoard.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;

    public abstract class GenericRepository<T> where T : class
    {
        protected JobBoardContext Context;

        protected IQueryable<T> PrepareQuery(
            IQueryable<T> query,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null
        )
        {
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (take.HasValue)
                query = query.Take(Convert.ToInt32(take));

            return query;
        }

        #region Get Records
        
        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy, take);

            return query.AsNoTracking().ToList();
        }
        
        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy, take);

            return await query.AsNoTracking().ToListAsync();
        }

        #endregion

        #region Single

        public virtual T Single(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return query.Single();
        }

        public virtual async Task<T> SingleAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = Context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return await query.SingleAsync();
        }

        #endregion

        #region Add

        public virtual void Add(T t)
        {
            Context.Add(t);
        }

        public virtual void Add(IEnumerable<T> t)
        {
            Context.AddRange(t);
        }

        public virtual async Task AddAsync(T t)
        {
            await Context.AddAsync(t);
        }

        public virtual async Task AddAsync(IEnumerable<T> t)
        {
            await Context.AddRangeAsync(t);
        }

        #endregion

        #region Remove

        public virtual void Remove(T t)
        {
            Context.Remove(t);            
        }

        public virtual void Remove(IEnumerable<T> t)
        {            
            Context.RemoveRange(t);
        }

        #endregion
        
        #region Update

        public virtual void Update(T t)
        {
            Context.Update(t);
        }

        public virtual void Update(IEnumerable<T> t)
        {
            Context.UpdateRange(t);
        }

        #endregion
    }
}