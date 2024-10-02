using AutoMapper;
using Cafe.BusinessLogic.Command.Users.Queries;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Users.QueriesHandler
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUserQuery, ServiceResponse<List<UserDto>>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _userRepository.GetAllFirst().ToListAsync();
                return ServiceResponse<List<UserDto>>.ReturnResultWith200(_mapper.Map<List<UserDto>>(entities));

            }
            catch (Exception ex)
            {

                return ServiceResponse<List<UserDto>>.ReturnException(ex);
            }        
        }
    }
}
