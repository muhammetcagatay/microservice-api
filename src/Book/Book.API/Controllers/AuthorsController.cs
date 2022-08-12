using Book.API.Data;
using Book.API.Filters;
using Book.API.Models.Entities;
using Book.API.Models.Request.Authors;
using Book.API.Services.Authors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(NotFoundFilter<Author>))]
    public class AuthorsController : CustomController
    {
        private readonly IAuthorService _service;
        public AuthorsController(IAuthorService service)
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
            return CreateResult(await _service.GetAuthorWithBooksAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuthorRequest request)
        {
            return CreateResult(await _service.CreateAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,AuthorRequest request)
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
