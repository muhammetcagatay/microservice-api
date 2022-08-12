using Book.API.Models.Request.Categories;
using Book.API.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomController
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateResult(await _service.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateResult(await _service.GetAllAsync());
        }
        [HttpGet("getwithbooks/{id}")]
        public async Task<IActionResult> GetWithBooks(int id)
        {
            return CreateResult(await _service.GetCategoryWithBooksAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            return CreateResult(await _service.CreateAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryRequest request)
        {
            return CreateResult(await _service.UpdateAsync(id, request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateResult(await _service.DeleteAsync(id));
        }
    }
}
