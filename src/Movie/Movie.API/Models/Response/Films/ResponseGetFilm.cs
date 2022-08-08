using Movie.API.Models.Entities;
using Movie.API.Models.Enums;

namespace Movie.API.Models.Response.Films
{
    public class ResponseGetFilm : ResponseFilm
    {
        public string Id { get; set; }
    }
}
