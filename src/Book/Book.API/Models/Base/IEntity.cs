using System.ComponentModel.DataAnnotations.Schema;
namespace Book.API.Models.Base
{
    public class IEntity
    {
        public IEntity()
        {
            IsDelete = false;
        }
        [Column("id")]
        public int Id { get; set; }
        [Column("isdelete")]
        public bool IsDelete { get; set; }
    }
}
