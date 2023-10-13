using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Startup.Data.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [MaxLength(255)]
        public string? CategoryName { get; set; }
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}