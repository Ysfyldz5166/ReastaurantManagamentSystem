using AutoMapper;
using Cafe.BusinessLogic.Command.Users.Queries;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Users.QueriesHandler
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ServiceResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetSingleAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                return ServiceResponse<UserDto>.Return404();
            }

            var userDto = _mapper.Map<UserDto>(entity);

            return ServiceResponse<UserDto>.ReturnResultWith200(userDto);
        }

    }
}
