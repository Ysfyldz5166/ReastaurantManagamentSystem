using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Command;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Categories;
using Cafe.Repository.Foods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Categories.CommandHandler
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, ServiceResponse<FoodDto>>
    {
        private readonly IFoodRepository _foodReapository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;

        public UpdateFoodCommandHandler(IFoodRepository foodReapository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork)
        {
            _foodReapository = foodReapository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<FoodDto>> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _foodReapository.FindByFirstAsync(a => a.Id == request.Id);  
                if (entity != null)
                {
                    _mapper.Map(request, entity);
                    _foodReapository.Update(entity);
                    await _unitOfWork.SaveAsync();
                    return ServiceResponse<FoodDto>.ReturnResultWith200(_mapper.Map<FoodDto>(entity));
                }
                else
                {
                    return ServiceResponse<FoodDto>.Return404();
                }
            }
            catch (Exception ex)
            {
                return ServiceResponse<FoodDto>.ReturnException(ex);
            }
        }
    }
}
