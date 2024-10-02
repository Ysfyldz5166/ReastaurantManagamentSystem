using Cafe.DataAcces.GenericRepository;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Entities;
using Cafe.Repository.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository.Users
{
    public class UserRepository : GenericRepository<User, CafeDbContext>,
          IUserRepository
    {
        public UserRepository(IUnitOfWork<CafeDbContext> uow) : base(uow)
        {
        }
    }
}
