﻿using Cafe.Entities.Dto;
using Cafe.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Command.Categories.Query
{
    public class GetCategoryQuery : IRequest<ServiceResponse<CategoryDto>>
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }    
    }
}
