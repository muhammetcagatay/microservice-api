using Movie.API.Models.Base;

namespace Movie.API.Models.Entities
{
    public class Category : IEntity
    {
        public Category()
        {
            FilmsId = new List<string>();
        }
        public string Name { get; set; }
        public List<string> FilmsId { get; set; }
    }
}
