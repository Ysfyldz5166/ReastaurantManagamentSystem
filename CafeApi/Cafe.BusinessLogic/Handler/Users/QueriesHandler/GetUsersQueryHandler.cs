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
    public class GetUsersQueryHandler : IRequestHandler<GetUserQuery, ServiceResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByFirstAsync(a=>a.Email == request.Email);
            if (user == null)
            {
                return ServiceResponse<UserDto>.ReturnError400("Kullanıcı Adı veya Şifre Hatalı");
            }
            else if (!PasswordHasher.VerifyPassword(user.PasswordHash, request.Password))
            {
                return ServiceResponse<UserDto>.ReturnError400("Kullanıcı Adı veya Şifre Hatalı");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return ServiceResponse<UserDto>.ReturnResultWith200(userDto);
        }
    }
}
