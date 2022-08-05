namespace Movie.API.Models.Response.Actors
{
    public class ResponseActor : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDayDate { get; set; }
    }
}
