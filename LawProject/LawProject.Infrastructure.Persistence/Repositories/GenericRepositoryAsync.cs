using LawProject.Application.Interfaces;
using LawProject.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Persistence.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Attach(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbContext.Set<T>().Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbContext.Set<T>().Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .AsNoTracking()
                 .ToListAsync();
        }
        public async Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbContext.Set<T>().AsNoTracking();
                foreach (var include in includes)
                    query = query.Include(include).AsTracking();

                return await query.FirstOrDefaultAsync(expression);
            }

            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbContext.Set<T>().AsNoTracking();
                foreach (var include in includes)
                    query = query.Include(include).AsTracking(); ;
                return query.AsQueryable();
            }

            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<int> Count(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().CountAsync(where);
        }

        public async Task<bool> CheckContains(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().CountAsync<T>(predicate) > 0;
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(where).AsTracking().AsQueryable();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbContext.Set<T>().AsNoTracking();
                foreach (var include in includes)
                    query = query.Include(include).AsTracking();
                return query.Where<T>(predicate).AsTracking().AsQueryable<T>();
            }

            return _dbContext.Set<T>().AsNoTracking().Where<T>(predicate).AsTracking().AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 1, int size = 20, string[] includes = null)
        {
            int skipCount = (index - 1) * size;
            IQueryable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbContext.Set<T>().AsNoTracking();
                foreach (var include in includes)
                    query = query.Include(include).AsTracking();
                _resetSet = predicate != null ? query.Where<T>(predicate).AsTracking().AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = predicate != null ? _dbContext.Set<T>().AsNoTracking().Where<T>(predicate).AsTracking().AsQueryable() : _dbContext.Set<T>().AsNoTracking().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }


        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
