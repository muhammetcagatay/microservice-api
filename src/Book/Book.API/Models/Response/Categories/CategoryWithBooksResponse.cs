using Book.API.Models.Response.Books;

namespace Book.API.Models.Response.Categories
{
    public class CategoryWithBooksResponse : CategoryResponse
    {
        public ICollection<BookResponse> Books { get; set; }
    }
}
