using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Command;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Entities.Entities;
using Cafe.Helper;
using Cafe.Repository.Categories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Categories.CommandHandler
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ServiceResponse<CategoryDto>>
    {

        private readonly ICategoryReapository _categoryReapository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        private readonly ILogger<AddCategoryCommandHandler> _logger;

        public AddCategoryCommandHandler(ICategoryReapository categoryReapository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork, ILogger<AddCategoryCommandHandler> logger)
        {
            _categoryReapository = categoryReapository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public  async Task<ServiceResponse<CategoryDto>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity =  _mapper.Map<Category>(request);

            if (entity != null)
            {
                await _categoryReapository.AddAsync(entity);

                if (await _unitOfWork.SaveAsync() > 0)
                {
                    var entityDto = _mapper.Map<CategoryDto>(entity);
                    return ServiceResponse<CategoryDto>.ReturnResultWith200(entityDto);

                }else
                {
                    return ServiceResponse<CategoryDto>.Return500();
                }
            }else
            {
                return ServiceResponse<CategoryDto>.Return404();
            }

        }
    }
}
