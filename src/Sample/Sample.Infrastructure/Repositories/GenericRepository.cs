//using Microsoft.EntityFrameworkCore;
//using Sample.Domain.Interfaces;
//using Sample.Domain.Models;
//using Sample.Infrastructure.DataAccess;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sample.Infrastructure.Repositories
//{
//    public class GenericRepository<T> : IGenericRepository<T> where T : class
//    {
//        private readonly SampleDbContext _context;

//        public GenericRepository(SampleDbContext context)
//        {
//            _context = context;
//        }

//        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null)
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            return query;
//        }

//        public async Task AddAsync(T entity)
//        {
//            await _context.Set<T>().AddAsync(entity);
//        }

//        public void Delete(T entity)
//        {
//            _context.Set<T>().Remove(entity);
//        }

//        public async Task<IEnumerable<T>> GetAllAsync()
//        {
//            return await _context.Set<T>()
//                         .OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"))
//                         .ToListAsync();
//        }

//        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeProperties)
//        {
//            IQueryable<T> query = _context.Set<T>();
//            if (includeProperties != null)
//            {
//                foreach (var includeProperty in includeProperties)
//                {
//                    query = query.Include(includeProperty);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            query = query.OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"));
//            return await query.ToListAsync();
//        }


//        public async Task<IEnumerable<T>> GetAllIncludingDeletedAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (includeProperties != null)
//            {
//                foreach (var includeProperty in includeProperties)
//                {
//                    query = query.Include(includeProperty);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            query = query.OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"));

//            return await query.ToListAsync();
//        }

//        public async Task<IEnumerable<T>> GetAllAsync(
//            Expression<Func<T, bool>> expression,
//            Expression<Func<T, object>> orderBy,
//            bool isDescending = false,
//            params Expression<Func<T, object>>[] includeProperties)
//        {
//            IQueryable<T> query = _context.Set<T>();
//            if (includeProperties != null)
//            {
//                foreach (var includeProperty in includeProperties)
//                {
//                    query = query.Include(includeProperty);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            if (orderBy != null)
//            {
//                query = isDescending
//                    ? query.OrderByDescending(orderBy)
//                    : query.OrderBy(orderBy);
//            }

//            query = query.OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"));
//            return await query.ToListAsync();
//        }

//        public async Task<T> GetLoadingAsync(Expression<Func<T, bool>> expression, params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions)
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (includeExpressions != null)
//            {
//                foreach (var include in includeExpressions)
//                {
//                    query = include(query);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            return await query.FirstOrDefaultAsync();
//        }

//        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
//        {
//            IQueryable<T> query = _context.Set<T>();
//            if (includeProperties != null)
//            {
//                foreach (var includeProperty in includeProperties)
//                {
//                    query = query.Include(includeProperty);
//                }
//            }
//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            return await query.FirstOrDefaultAsync();
//        }

//        public async Task<T> GetIncludingDeleteAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (includeProperties != null)
//            {
//                foreach (var includeProperty in includeProperties)
//                {
//                    query = query.Include(includeProperty);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            return await query.FirstOrDefaultAsync();
//        }

//        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
//        {
//            IQueryable<T> query = _context.Set<T>();
//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            return await query.FirstOrDefaultAsync();
//        }

//        public void Update(T entity)
//        {
//            PropertyInfo propertyInfo = entity.GetType().GetProperty("UpdatedAt");
//            propertyInfo.SetValue(entity, DateTime.Now);
//            _context.Set<T>().Update(entity);
//        }

//        public void RemoveRange(IEnumerable<T> entities)
//        {
//            _context.Set<T>().RemoveRange(entities);
//        }

//        public async Task<RepositoryPaginationResponse<T>> GetListAsync(Expression<Func<T, bool>> expression, int limit, int offset, params Expression<Func<T, object>>[] includeProperties)
//        {
//            IQueryable<T> query = _context.Set<T>();
//            if (includeProperties != null)
//            {
//                foreach (var includeProperty in includeProperties)
//                {
//                    query = query.Include(includeProperty);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            query = query.OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"));

//            var total = await query.CountAsync();
//            query = query.Skip(offset).Take(limit);
//            var data = await query.ToListAsync();
//            return new RepositoryPaginationResponse<T>
//            {
//                Data = data,
//                Total = total
//            };
//        }

//        public async Task<RepositoryPaginationResponse<T>> GetLoadingListAsync(
//            Expression<Func<T, bool>> expression,
//            int limit,
//            int offset,
//            Expression<Func<T, object>> orderBy,
//            bool isDescending = false,
//            params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions
//        )
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (includeExpressions != null)
//            {
//                foreach (var include in includeExpressions)
//                {
//                    query = include(query);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }
//            query = query.OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"));

//            if (orderBy != null)
//            {
//                query = isDescending
//                    ? query.OrderByDescending(orderBy)
//                    : query.OrderBy(orderBy);
//            }

//            var total = await query.CountAsync();
//            query = query.Skip(offset).Take(limit);
//            var data = await query.ToListAsync();
//            return new RepositoryPaginationResponse<T>
//            {
//                Data = data,
//                Total = total
//            };
//        }

//        public async Task<RepositoryPaginationResponse<T>> GetLoadingListAsync(Expression<Func<T, bool>> expression, int limit, int offset, params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions)
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (includeExpressions != null)
//            {
//                foreach (var include in includeExpressions)
//                {
//                    query = include(query);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }
//            query = query.OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"));

//            var total = await query.CountAsync();
//            query = query.Skip(offset).Take(limit);
//            var data = await query.ToListAsync();
//            return new RepositoryPaginationResponse<T>
//            {
//                Data = data,
//                Total = total
//            };
//        }

//        public async Task<RepositoryPaginationResponse<T>> GetLoadingListAsync(Expression<Func<T, bool>> expression, params Func<IQueryable<T>, IQueryable<T>>[] includeExpressions)
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (includeExpressions != null)
//            {
//                foreach (var include in includeExpressions)
//                {
//                    query = include(query);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }
//            query = query.OrderByDescending(entity => EF.Property<DateTime>(entity, "CreatedAt"));

//            var total = await query.CountAsync();
//            var data = await query.ToListAsync();
//            return new RepositoryPaginationResponse<T>
//            {
//                Data = data,
//                Total = total
//            };
//        }

//        public async Task<RepositoryPaginationResponse<T>> GetListAsync(
//            Expression<Func<T, bool>> expression,
//            int limit,
//            int offset,
//            Expression<Func<T, object>> orderBy,
//            bool isDescending = false,
//            params Expression<Func<T, object>>[] includeProperties)
//        {
//            IQueryable<T> query = _context.Set<T>();

//            if (includeProperties != null)
//            {
//                foreach (var includeProperty in includeProperties)
//                {
//                    query = query.Include(includeProperty);
//                }
//            }

//            if (expression != null)
//            {
//                query = query.Where(expression);
//            }

//            if (orderBy != null)
//            {
//                query = isDescending
//                    ? query.OrderByDescending(orderBy)
//                    : query.OrderBy(orderBy);
//            }

//            var total = await query.CountAsync();

//            query = query.Skip(offset).Take(limit);

//            var data = await query.ToListAsync();

//            return new RepositoryPaginationResponse<T>
//            {
//                Data = data,
//                Total = total
//            };
//        }

//        public async Task AddRangeAsync(IEnumerable<T> entities)
//        {
//            await _context.Set<T>().AddRangeAsync(entities);
//        }

//        public void DeleteRange(IEnumerable<T> entities)
//        {
//            _context.Set<T>().RemoveRange(entities);
//        }

//        public async Task SaveAsync()
//        {
//            await _context.SaveChangesAsync();
//        }
//    }
//}
