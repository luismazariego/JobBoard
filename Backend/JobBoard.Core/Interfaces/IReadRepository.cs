namespace JobBoard.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Query;

    public interface IReadRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );

        T Single(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );

        Task<T> SingleAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );
    }
}