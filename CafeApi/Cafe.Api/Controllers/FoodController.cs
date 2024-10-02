using Cafe.BusinessLogic.Command.Categories.Command;
using Cafe.BusinessLogic.Command.Categories.Query;
using Cafe.Entities.Dto;
using Cafe.Helper;
using CafeApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : BaseController
    {
        private readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Food Id
        /// </summary>
        /// <param name="getFoodQuery"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<FoodDto>))]
        public async Task<IActionResult> GetById(GetFoodQuery getFoodQuery)
        {
            var result = await _mediator.Send(getFoodQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Food List
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [Produces("application/json", "application/xml", Type = typeof(List<FoodDto>))]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetAllFoodQuery { });

            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Create Add Food.
        /// </summary>
        /// <param name="addFoodCommand"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<FoodDto>))]
        public async Task<IActionResult> Add(AddFoodCommand addFoodCommand)
        {
            var result = await _mediator.Send(addFoodCommand);
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
            var result = await _mediator.Send(new DeleteFoodCommand { Id = Id });
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Update City.
        /// </summary>
        /// <param name="updateFoodCommand"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [Produces("application/json", "application/xml", Type = typeof(UpdateFoodCommand))]
        public async Task<IActionResult> Update(UpdateFoodCommand UpdateFoodCommand)
        {
            var result = await _mediator.Send(UpdateFoodCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
