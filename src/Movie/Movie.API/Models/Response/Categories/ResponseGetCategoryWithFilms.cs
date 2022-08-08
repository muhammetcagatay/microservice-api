using Movie.API.Models.Response.Films;

namespace Movie.API.Models.Response.Categories
{
    public class ResponseGetCategoryWithFilms : ResponseCategory
    {
        public List<ResponseFilm> Films { get; set; }
    }
}
