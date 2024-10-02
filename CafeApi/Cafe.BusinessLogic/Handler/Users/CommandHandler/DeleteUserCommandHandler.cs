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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ServiceResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<CafeDbContext> _unitOfWork;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork<CafeDbContext> unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<UserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.FindByFirstAsync(x => x.Id == request.Id);
            _userRepository.Remove(entity);

            if (await _unitOfWork.SaveAsync() <= 0)
            {
                return ServiceResponse<UserDto>.Return500();
            }

            var entityDto = _mapper.Map<UserDto>(entity);
            return ServiceResponse<UserDto>.ReturnResultWith200(entityDto);
        }
    }
}
