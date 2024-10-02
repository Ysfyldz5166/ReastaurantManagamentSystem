using AutoMapper;
using Cafe.BusinessLogic.Command.Categories.Command;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Categories.CommandHandler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<CategoryDto>>
    {
        private readonly ICategoryReapository _categoryReapository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryReapository categoryReapository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork)
        {
            _categoryReapository = categoryReapository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _categoryReapository.FindByFirstAsync(a => a.Id == request.Id);  
                if (entity != null)
                {
                    _mapper.Map(request, entity);
                    _categoryReapository.Update(entity);
                    await _unitOfWork.SaveAsync();
                    return ServiceResponse<CategoryDto>.ReturnResultWith200(_mapper.Map<CategoryDto>(entity));
                }
                else
                {
                    return ServiceResponse<CategoryDto>.Return404();
                }
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.ReturnException(ex);
            }
        }
    }
}
