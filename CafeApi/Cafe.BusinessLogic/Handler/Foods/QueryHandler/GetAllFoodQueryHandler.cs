using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Query;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Categories;
using Cafe.Repository.Foods;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Categories.QueryHandler
{
    public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery, ServiceResponse<List<FoodDto>>>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public GetAllFoodQueryHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<FoodDto>>> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _foodRepository.GetAllFirst().ToListAsync();
                return ServiceResponse<List<FoodDto>>.ReturnResultWith200(_mapper.Map<List<FoodDto>>(entities));
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<FoodDto>>.ReturnException(ex);
            }
        }
    }
}
