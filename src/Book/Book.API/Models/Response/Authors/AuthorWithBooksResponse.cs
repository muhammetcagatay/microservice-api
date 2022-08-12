using Book.API.Models.Entities;
using Book.API.Models.Response.Books;

namespace Book.API.Models.Response.Authors
{
    public class AuthorWithBooksResponse : AuthorResponse
    {
        public ICollection<BookResponse> Books { get; set; }
    }
}
