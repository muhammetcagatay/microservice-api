using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Movie.API.Data;
using Movie.API.Models.Entities;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMongoDataContext _context;
        private readonly IMongoCollection<Film> _filmCollection;
        private readonly IMongoCollection<Actor> _actorCollection;

        public CategoriesController(IMongoDataContext context)
        {
            _context = context;
            _filmCollection = _context.GetCollection<Film>(typeof(Film).Name);
            _actorCollection = _context.GetCollection<Actor>(typeof(Actor).Name);

            var film = _filmCollection.Find(x => x.Id == "62ecda0d6e46c641100ce040").FirstOrDefault();

            film.Actors = new List<string>()
            {
                "62ecda0d6e46c641100ce042",
                "62ecda0d6e46c641100ce041"
            };

            _filmCollection.FindOneAndReplace(x => x.Id==film.Id,film);
        }
        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok("Doğru");
        }
        

    }
}
