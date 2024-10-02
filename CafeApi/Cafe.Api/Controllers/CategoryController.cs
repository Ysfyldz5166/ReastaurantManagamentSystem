using AutoMapper;
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
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Get Category Id
        /// </summary>
        /// <param name="getCategoryQuery"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<CategoryDto>))]
        public async Task<IActionResult> GetById(GetCategoryQuery getCategoryQuery)
        {
            var result = await _mediator.Send(getCategoryQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get All Category List
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [Produces("application/json", "application/xml", Type = typeof(List<CategoryDto>))]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery { });

            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Create Add Category.
        /// </summary>
        /// <param name="addCategoryCommand"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<CategoryDto>))]
        public async Task<IActionResult> Add(AddCategoryCommand addCategoryCommand)
        {
            var result = await _mediator.Send(addCategoryCommand);
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
            var result = await _mediator.Send(new DeleteCategoryCommand { Id = Id });
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Update City.
        /// </summary>
        /// <param name="updateCategoryCommand"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [Produces("application/json", "application/xml", Type = typeof(UpdateCategoryCommand))]
        public async Task<IActionResult> Update(UpdateCategoryCommand UpdateCategoryCommand)
        {
            var result = await _mediator.Send(UpdateCategoryCommand);
            return ReturnFormattedResponse(result);
        }
    }
}
