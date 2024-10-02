using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Query;
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

namespace Cafe.BusinessLogic.Handler.Categories.QueryHandler
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, ServiceResponse<FoodDto>>
    {
        private readonly IFoodRepository _foodReapository;
        private readonly IMapper _mapper;

        public GetFoodQueryHandler(IFoodRepository foodReapository, IMapper mapper)
        {
            _foodReapository = foodReapository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FoodDto>> Handle(GetFoodQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _foodReapository.FindByFirstAsync(a => a.Id == request.Id);

                return ServiceResponse<FoodDto>.ReturnResultWith200(_mapper.Map<FoodDto>(entity));
            }
            catch (Exception)
            {

                return ServiceResponse<FoodDto>.Return404();
            }
        }
    }
}
