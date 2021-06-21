using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll(string[] includes = null);
        Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteMulti(Expression<Func<T, bool>> where);
        Task<int> Count(Expression<Func<T, bool>> where);
        Task<bool> CheckContains(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null);
        void Dispose();
        void Save();
        Task<int> SaveAsync();
    }
}
