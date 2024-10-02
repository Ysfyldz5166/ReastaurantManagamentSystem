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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse<CategoryDto>>
    {
        private readonly ICategoryReapository _categoryReapository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        public DeleteCategoryCommandHandler(ICategoryReapository categoryReapository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork)
        {
            _categoryReapository = categoryReapository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<ServiceResponse<CategoryDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var enity = await  _categoryReapository.FindByFirstAsync(a => a.Id == request.Id);

                    _categoryReapository.Remove(enity);

                    if (await _unitOfWork.SaveAsync() > 0)
                    {
                        return ServiceResponse<CategoryDto>.ReturnResultWith201(_mapper.Map<CategoryDto>(enity));

                    }
                    else
                    {
                        return ServiceResponse<CategoryDto>.Return500();
                    }

            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.ReturnException(ex);
            }
        }
    }
}
