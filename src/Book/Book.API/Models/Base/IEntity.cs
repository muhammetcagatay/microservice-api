using System.ComponentModel.DataAnnotations.Schema;
namespace Book.API.Models.Base
{
    public class IEntity
    {
        public IEntity()
        {
            CreatedDate = DateTime.Now;
            IsDelete = false;
        }
        [Column("id")]
        public int Id { get; set; }
        [Column("createddate")]
        public DateTime CreatedDate { get; set; }
        [Column("updateddate")]
        public DateTime? UpdatedDate { get; set; }
        [Column("isdelete")]
        public bool IsDelete { get; set; }
    }
}
