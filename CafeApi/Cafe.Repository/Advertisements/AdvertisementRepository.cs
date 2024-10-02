using Cafe.DataAcces.GenericRepository;
using Cafe.DataAcces.UnitOfWork;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.Entities.Entities;

using Cafe.Repository.Advertisements;

namespace Cafe.Repository.Advertisement
{
    public class AdvertisementRepository : GenericRepository<Adverisement, CafeDbContext>,
          IAdvertisementRepository
    {
        public AdvertisementRepository(IUnitOfWork<CafeDbContext> uow) : base(uow)
        {
        }
    }
}
