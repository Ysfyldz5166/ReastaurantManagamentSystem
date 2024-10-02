using Cafe.Entities.Dto;
using Cafe.Entities.Entities;
using Cafe.Helper;
using MediatR;
using MediatR.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Command.Categories.Query
{
    public class GetAllCategoryQuery : IRequest<ServiceResponse<List<CategoryDto>>>
    {
    }
}
