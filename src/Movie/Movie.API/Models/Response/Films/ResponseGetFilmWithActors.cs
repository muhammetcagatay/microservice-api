using Movie.API.Models.Response.Actors;

namespace Movie.API.Models.Response.Films
{
    public class ResponseGetFilmWithActors : ResponseFilm
    {
        public List<ResponseGetActor> Actors { get; set; }
    }
}
