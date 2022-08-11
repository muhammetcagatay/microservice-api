using Book.API.Models.Base;
using Book.API.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.API.Models.Entities
{
    [Table("authors")]
    public class Author : IEntity
    {
        public Author()
        {
            Books = new HashSet<BookEntity>();
        }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        public ICollection<BookEntity> Books { get; set; }
    }
}
