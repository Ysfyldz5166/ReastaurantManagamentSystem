using AutoMapper;
using FluentValidation;
using Cafe.BusinessLogic.Command.Users.Command;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Entities.Entities;
using Cafe.Helper;
using Cafe.Repository.Users;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Users.CommandHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ServiceResponse<UserDto>>
    {
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddUserCommandHandler> _logger;


        public AddUserCommandHandler(IUnitOfWork<CafeDbContext> unitOfWork, IUserRepository userRepository, IMapper mapper, ILogger<AddUserCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<UserDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<User>(request);
                entity.PasswordHash = PasswordHasher.HashPassword(request.Password);
                await _userRepository.AddAsync(entity);

                if (await _unitOfWork.SaveAsync() <= 0)
                {
                    return ServiceResponse<UserDto>.Return500();
                }
                else
                {
                    var entityDto = _mapper.Map<UserDto>(entity);

                    return ServiceResponse<UserDto>.ReturnResultWith200(entityDto);
                }
            }
            catch (Exception ex)
            {
                return ServiceResponse<UserDto>.ReturnException(ex);
            }
        }
    }
}
