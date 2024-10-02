using Cafe.BusinessLogic.Command.Advertisement;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Advertisements;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Advertisements
{
    public class GetAdvertisementsQueryHandler : IRequestHandler<GetAdvertisementsQuery, ServiceResponse<List<AdvertisemetDto>>>
    {
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        private readonly IAdvertisementRepository _advertisementRepository;

        public GetAdvertisementsQueryHandler(IUnitOfWork<CafeDbContext> unitOfWork, IAdvertisementRepository advertisementRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementRepository;
        }

        public async Task<ServiceResponse<List<AdvertisemetDto>>> Handle(GetAdvertisementsQuery request, CancellationToken cancellationToken)
        {
            var advertisements = await _advertisementRepository.GetAll();
            var advertisementDtos = advertisements.Select(a => new AdvertisemetDto
            {
                Id = a.Id,
                Name = a.Name,
                Price = a.Price
            }).ToList();

            return ServiceResponse<List<AdvertisemetDto>>.ReturnResultWith200(advertisementDtos);
        }
    }
}
