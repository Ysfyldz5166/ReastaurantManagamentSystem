using Cafe.DataAcces.GenericRepository;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository.Categories
{
    public class CategoryRepository : GenericRepository<Category, CafeDbContext>, ICategoryReapository
    {
        public CategoryRepository(IUnitOfWork<CafeDbContext> uow) : base(uow)
        {
        }
    }
}
