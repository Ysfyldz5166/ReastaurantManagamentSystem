using Cafe.DataAcces.GenericRepository;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository.Foods
{
    public class FoodRepository : GenericRepository<Food, CafeDbContext>, IFoodRepository
    {
        public FoodRepository(IUnitOfWork<CafeDbContext> uow) : base(uow)
        {
        }
    }
}
