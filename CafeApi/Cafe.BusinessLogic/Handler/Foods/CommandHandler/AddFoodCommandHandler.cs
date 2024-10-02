using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Command;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Entities.Entities;
using Cafe.Helper;
using Cafe.Repository.Categories;
using Cafe.Repository.Foods;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Categories.CommandHandler
{
    public class AddFoodCommandHandler : IRequestHandler<AddFoodCommand, ServiceResponse<FoodDto>>
    {

        private readonly IFoodRepository _foodReapository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        private readonly ILogger<AddFoodCommandHandler> _logger;

        public AddFoodCommandHandler(IFoodRepository foodReapository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork, ILogger<AddFoodCommandHandler> logger)
        {
            _foodReapository = foodReapository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public  async Task<ServiceResponse<FoodDto>> Handle(AddFoodCommand request, CancellationToken cancellationToken)
        {
            var entity =  _mapper.Map<Food>(request);

            if (entity != null)
            {
                await _foodReapository.AddAsync(entity);

                if (await _unitOfWork.SaveAsync() > 0)
                {
                    var entityDto = _mapper.Map<FoodDto>(entity);
                    return ServiceResponse<FoodDto>.ReturnResultWith200(entityDto);

                }else
                {
                    return ServiceResponse<FoodDto>.Return500();
                }
            }else
            {
                return ServiceResponse<FoodDto>.Return404();
            }

        }
    }
}
