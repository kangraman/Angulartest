using System.ComponentModel.DataAnnotations.Schema;

namespace Angularapi.Models
{
    public class PRODUCT
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IMAGE { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
