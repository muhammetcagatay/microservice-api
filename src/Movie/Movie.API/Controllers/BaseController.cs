using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Models.Base;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateResult<T>(Response<T> response)
        {
            return new ObjectResult(response.Data)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
