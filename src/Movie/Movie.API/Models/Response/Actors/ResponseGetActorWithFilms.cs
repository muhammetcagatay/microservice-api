using Movie.API.Models.Response.Films;

namespace Movie.API.Models.Response.Actors
{
    public class ResponseGetActorWithFilms : ResponseFilm
    {
        public List<ResponseGetFilm> Films { get; set; }
    }
}
