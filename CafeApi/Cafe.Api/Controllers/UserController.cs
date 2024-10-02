using Cafe.BusinessLogic.Command.Users.Command;
using Cafe.BusinessLogic.Command.Users.Queries;
using Cafe.Entities.Dto;
using Cafe.Helper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get User by Email or Username
        /// </summary>
        /// <param name="getUserQuery"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<UserDto>))]
        public async Task<IActionResult> Login(GetUserQuery getUserQuery)
        {
            var result = await _mediator.Send(getUserQuery);
            return ReturnFormattedResponse(result);
        }


        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", "application/xml", Type = typeof(UserDto))]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { Id = Id });

            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Users List
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [Produces("application/json", "application/xml", Type = typeof(List<UserDto>))]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetAllUserQuery { } );

            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Create Add User.
        /// </summary>
        /// <param name="addUserCommand"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<UserDto>))]
        public async Task<IActionResult> Add(AddUserCommand addUserCommand)
        {
            var result = await _mediator.Send(addUserCommand);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = Id });
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Update City.
        /// </summary>
        /// <param name="updateUserCommand"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [Produces("application/json", "application/xml", Type = typeof(UpdateUserCommand))]
        public async Task<IActionResult> Update(UpdateUserCommand UpdateUserCommand)
        {
            var result = await _mediator.Send(UpdateUserCommand);
            return ReturnFormattedResponse(result);
        }
    }
}