using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.DataAcces.GenericRepository
{
    public class GenericRepository<T, C> : IGenericRepository<T> where T : class where C : DbContext
    {
        protected readonly C _context;

        public DbSet<T> Table => _context.Set<T>();

        public GenericRepository(IUnitOfWork<C> uow)
        {
            _context = uow.Context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public IQueryable<T> GetAllFirst()
        {
            return Table;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsyc(string id)
        {
            return await Table.FindAsync(id);
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T model= await Table.FindAsync(id);
            EntityEntry<T> entityEntry=Table.Remove(model);
            return  entityEntry.State == EntityState.Deleted;
            
        }
        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public async Task<T> FindByFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }

    }

}
