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
    public class GetAdvertisementByIdQueryHandler : IRequestHandler<GetAdvertisementByIdQuery, ServiceResponse<AdvertisemetDto>>
    {
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        private readonly IAdvertisementRepository _advertisementRepository;

        public GetAdvertisementByIdQueryHandler(IUnitOfWork<CafeDbContext> unitOfWork, IAdvertisementRepository advertisementRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementRepository;
        }

        public async Task<ServiceResponse<AdvertisemetDto>> Handle(GetAdvertisementByIdQuery request, CancellationToken cancellationToken)
        {
            var advertisement = await _advertisementRepository.GetById(request.Id);
            if (advertisement == null)
            {
                return ServiceResponse<AdvertisemetDto>.Return404();
            }

            var advertisementDto = new AdvertisemetDto
            {
                Id = advertisement.Id,
                Name = advertisement.Name,
                Price = advertisement.Price
            };
                
            return ServiceResponse<AdvertisemetDto>.ReturnResultWith200(advertisementDto);
        }
    }

}
