using Microsoft.AspNetCore.Mvc;
using Movie.API.Models.Request.Categories;
using Movie.API.Services.Categories;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
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
        [HttpGet("getwithfilms/{id}")]
        public async Task<IActionResult> GetWithFilms(string id)
        {
            return CreateResult(await _service.GetCategoryWithFilms(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequestCategory request)
        {
            return CreateResult(await _service.CreateAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id,RequestCategory request)
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
