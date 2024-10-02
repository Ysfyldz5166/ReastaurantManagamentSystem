using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.DataAcces.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {

        DbSet<T> Table { get; }
        IQueryable<T> GetAllFirst();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> FindByFirstAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsyc(string id);

        Task<bool> RemoveAsync(string id);

        void Update(T entity);   



        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }

}
