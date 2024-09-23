using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, object>> orderBy,
            bool isDescending = false,
            params Expression<Func<T, object>>[] includeProperties
            );

        Task<RepositoryPaginationResponse<T>> GetListAsync(
            Expression<Func<T, bool>> expression,
            int limit,
            int offset,
            params Expression<Func<T, object>>[] includeProperties
        );

        Task<RepositoryPaginationResponse<T>> GetListAsync(
            Expression<Func<T, bool>> expression,
            int limit,
            int offset,
            Expression<Func<T, object>> orderBy,
            bool isDescending = false,
            params Expression<Func<T, object>>[] includeProperties
        );

        Task<RepositoryPaginationResponse<T>> GetLoadingListAsync(
            Expression<Func<T, bool>> expression,
            int limit,
            int offset,
            Expression<Func<T, object>> orderBy,
            bool isDescending = false,
            params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions
        );

        Task<RepositoryPaginationResponse<T>> GetLoadingListAsync(
            Expression<Func<T, bool>> expression,
            int limit,
            int offset,
            params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions
        );

        Task<RepositoryPaginationResponse<T>> GetLoadingListAsync(
            Expression<Func<T, bool>> expression,
            params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions
        );

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetLoadingAsync(Expression<Func<T, bool>> expression, params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        Task SaveAsync();
    }
}
