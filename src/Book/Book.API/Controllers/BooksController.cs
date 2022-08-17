using Book.API.Filters;
using Book.API.Models.Entities;
using Book.API.Models.Request.Books;
using Book.API.Services.BookEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : CustomController
    {
        private readonly IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<BookEntity>))]
        public async Task<IActionResult> Get(int id)
        {
            return CreateResult(await _service.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateResult(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookRequest request)
        {
            return CreateResult(await _service.CreateAsync(request));
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<BookEntity>))]
        public async Task<IActionResult> Update(int id, BookRequest request)
        {
            return CreateResult(await _service.UpdateAsync(id, request));
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<BookEntity>))]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateResult(await _service.DeleteAsync(id));
        }
    }
}
