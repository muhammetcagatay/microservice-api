using Movie.API.Models.Enums;

namespace Movie.API.Models.Response.Films
{
    public class ResponseFilm : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Country Country { get; set; }
        public Language Language { get; set; }
        public int PublicationYear { get; set; }
        public string CategoryId { get; set; }
    }
}
