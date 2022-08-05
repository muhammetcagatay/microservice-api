namespace Movie.API.Models.Request.Actors
{
    public class RequestActor : BaseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDayDate { get; set; } = DateTime.Now;
    }
}
