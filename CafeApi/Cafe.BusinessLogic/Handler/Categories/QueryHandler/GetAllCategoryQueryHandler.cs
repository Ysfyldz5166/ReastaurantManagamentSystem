using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Query;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Categories.QueryHandler
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ServiceResponse<List<CategoryDto>>>
    {
        private readonly ICategoryReapository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryReapository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _categoryRepository.GetAllFirst().Include(c =>c.Foods).ToListAsync();
                return ServiceResponse<List<CategoryDto>>.ReturnResultWith200(_mapper.Map<List<CategoryDto>>(entities));
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<CategoryDto>>.ReturnException(ex);
            }
        }
    }
}
