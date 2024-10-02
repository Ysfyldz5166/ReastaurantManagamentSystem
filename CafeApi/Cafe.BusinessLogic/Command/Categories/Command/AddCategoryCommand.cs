﻿using Cafe.Entities.Dto;
using Cafe.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Command.Categories.Command
{
    public class AddCategoryCommand : IRequest<ServiceResponse<CategoryDto>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
