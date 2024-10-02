using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Query;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Categories.QueryHandler
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ServiceResponse<CategoryDto>>
    {
        private readonly ICategoryReapository _categoryReapository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(ICategoryReapository categoryReapository, IMapper mapper)
        {
            _categoryReapository = categoryReapository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _categoryReapository.FindByFirstAsync(a => a.Id == request.Id);

                return ServiceResponse<CategoryDto>.ReturnResultWith200(_mapper.Map<CategoryDto>(entity));
            }
            catch (Exception)
            {

                return ServiceResponse<CategoryDto>.Return404();
            }
        }
    }
}
