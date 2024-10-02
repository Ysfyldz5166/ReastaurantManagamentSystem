using Cafe.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult ReturnFormattedResponse<T>(ServiceResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response.Data);
            }
            if (response.Errors != null && response.Errors.Count > 0)
            {
                return BadRequest(new { errors = response.Errors });
            }
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}
