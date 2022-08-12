using Book.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
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
