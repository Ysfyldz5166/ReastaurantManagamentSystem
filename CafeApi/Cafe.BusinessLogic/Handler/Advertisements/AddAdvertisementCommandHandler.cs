using Cafe.BusinessLogic.Command;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Entities.Entities;
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

    public class AddAdvertisementCommandHandler : IRequestHandler<AddAdvertisementCommand, ServiceResponse<AdvertisemetDto>>
    {
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        private readonly IAdvertisementRepository _advertisementRepository;

        public AddAdvertisementCommandHandler(IUnitOfWork<CafeDbContext> unitOfWork, IAdvertisementRepository advertisementRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementRepository;
        }

        public async Task<ServiceResponse<AdvertisemetDto>> Handle(AddAdvertisementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var advertisement = new Adverisement
                {
                    Id = request.Id,
                    Name = request.Name,
                    Price = request.Price
                };

                await _advertisementRepository.AddAsync(advertisement);
                await _unitOfWork.SaveAsync();

                var responseDto = new AdvertisemetDto
                {
                    Id = advertisement.Id,
                    Name = advertisement.Name,
                    Price = advertisement.Price
                };

                return ServiceResponse<AdvertisemetDto>.ReturnResultWith201(responseDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AdvertisemetDto>.ReturnException(ex);
            }
        }
    }


}
