using Cafe.DataAcces.GenericRepository;
using Cafe.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.DataAcces.UnitOfWork
{
    public interface IUnitOfWork<C> : IDisposable where C : DbContext
    {
        C Context { get; }
        Task<int> SaveAsync();
    }
}
