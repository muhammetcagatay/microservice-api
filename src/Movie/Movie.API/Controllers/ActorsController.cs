using Microsoft.AspNetCore.Mvc;
using Movie.API.Models.Request.Actors;
using Movie.API.Services.Actors;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : BaseController
    {
        private readonly IActorService _service;
        private readonly ILogger<ActorsController> _logger;
        public ActorsController(IActorService service, ILogger<ActorsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return CreateResult(await _service.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateResult(await _service.GetAllAsync());
        }
        [HttpGet("getwithfilms/{id}")]
        public async Task<IActionResult> GetWithFilms(string id)
        {
            return CreateResult(await _service.GetActorWithFilms(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequestActor request)
        {
            return CreateResult(await _service.CreateAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id,RequestActor request)
        {
            return CreateResult(await _service.UpdateAsync(id,request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateResult(await _service.RemoveAsync(id));
        }
    }
}
