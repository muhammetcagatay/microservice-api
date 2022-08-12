using Book.API.Models.Base;
using Book.API.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.API.Models.Entities
{
    [Table("books")]
    public class BookEntity : IEntity
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("printlenght")]
        public int PrintLenght { get; set; }
        [Column("categoryid")]
        public int CategoryId { get; set; }
        [Column("authorid")]
        public int AuthorId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
    }
}
