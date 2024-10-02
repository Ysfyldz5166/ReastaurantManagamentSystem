using Cafe.DataAcces.GenericRepository;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.DataAcces.UnitOfWork
{
    public class UnitOfWork<C> : IUnitOfWork<C> where C : DbContext
    {
        public C Context { get; }

        public UnitOfWork(C context)
        {
            Context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
