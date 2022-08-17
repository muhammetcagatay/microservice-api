using Movie.API.Models.Response.Films;

namespace Movie.API.Models.Response.Actors
{
    public class ResponseGetActorWithFilms : ResponseActor
    {
        public List<ResponseGetFilm> Films { get; set; }
    }
}
