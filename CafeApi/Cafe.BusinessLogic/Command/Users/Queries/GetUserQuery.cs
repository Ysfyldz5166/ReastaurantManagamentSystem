﻿using Cafe.Entities.Dto;
using Cafe.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Command.Users.Queries
{
    public class GetUserQuery : IRequest<ServiceResponse<UserDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
