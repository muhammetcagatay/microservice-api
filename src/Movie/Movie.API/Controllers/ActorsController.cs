using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Services.Actors;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}
