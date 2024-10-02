using Cafe.DataAcces.GenericRepository;
using Cafe.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repository.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
