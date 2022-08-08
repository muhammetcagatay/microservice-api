using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Models.Request.Films;
using Movie.API.Services.Films;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : BaseController
    {
        private readonly IFilmService _service;

        public FilmsController(IFilmService service)
        {
            _service = service;
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
        [HttpGet("getwithactors/{id}")]
        public async Task<IActionResult> GetWithFilms(string id)
        {
            return CreateResult(await _service.GetFilmWithActors(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequestFilm request)
        {
            return CreateResult(await _service.CreateAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, RequestFilm request)
        {
            return CreateResult(await _service.UpdateAsync(id, request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateResult(await _service.RemoveAsync(id));
        }

    }
}
