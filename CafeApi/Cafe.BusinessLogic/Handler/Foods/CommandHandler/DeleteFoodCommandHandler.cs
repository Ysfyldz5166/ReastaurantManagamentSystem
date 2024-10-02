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
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, ServiceResponse<FoodDto>>
    {
        private readonly IFoodRepository _foodReapository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        public DeleteFoodCommandHandler(IFoodRepository foodReapository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork)
        {
            _foodReapository = foodReapository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<ServiceResponse<FoodDto>> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var enity = await  _foodReapository.FindByFirstAsync(a => a.Id == request.Id);

                    _foodReapository.Remove(enity);

                    if (await _unitOfWork.SaveAsync() > 0)
                    {
                        return ServiceResponse<FoodDto>.ReturnResultWith201(_mapper.Map<FoodDto>(enity));

                    }
                    else
                    {
                        return ServiceResponse<FoodDto>.Return500();
                    }

            }
            catch (Exception ex)
            {
                return ServiceResponse<FoodDto>.ReturnException(ex);
            }
        }
    }
}
