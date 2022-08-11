using Book.API.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.API.Models.Entities
{
    [Table("categories")]
    public class Category : IEntity
    {
        public Category()
        {
            Books = new HashSet<BookEntity>();
        }
        public string Name { get; set; }
        public ICollection<BookEntity> Books { get; set; }

    }
}
