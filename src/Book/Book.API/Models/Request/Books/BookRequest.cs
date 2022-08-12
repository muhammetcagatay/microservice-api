namespace Book.API.Models.Request.Books
{
    public class BookRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PrintLenght { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
