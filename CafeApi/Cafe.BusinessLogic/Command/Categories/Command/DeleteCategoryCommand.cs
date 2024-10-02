using Cafe.Entities.Dto;
using Cafe.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Command.Categories.Command
{
    public class DeleteCategoryCommand : IRequest<ServiceResponse<CategoryDto>>
    {
        public Guid Id { get; set; }
    }
}
