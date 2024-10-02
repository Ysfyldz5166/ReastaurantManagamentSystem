using AutoMapper;
using Cafe.BusinessLogic.Command.Users.Command;
using Cafe.DataAcces.CafeDbContexts;
using Cafe.DataAcces.UnitOfWork;
using Cafe.Entities.Dto;
using Cafe.Helper;
using Cafe.Repository.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.BusinessLogic.Handler.Users.CommandHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ServiceResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var IsPasswordHashed = false;

            var entity = await _userRepository.FindByFirstAsync(x => x.Id == request.Id);

            if (request.Password.Length!=44)
            {
                request.Password = PasswordHasher.HashPassword(request.Password);
            }

            _mapper.Map(request, entity);
            _userRepository.Update(entity);

            if (await _unitOfWork.SaveAsync() <= 0)
            {
                return ServiceResponse<UserDto>.Return500();
            }

            var entityDto = _mapper.Map<UserDto>(entity);
            return ServiceResponse<UserDto>.ReturnResultWith200(entityDto);
        }

    }
}
