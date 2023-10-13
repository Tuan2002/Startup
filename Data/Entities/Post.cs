using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Startup.Data.Entities
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public long PostID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        [MaxLength(255)]
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public string? Link { get; set; }
        public string? Author { get; set; }
        [MaxLength(50)]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int? PostOrder { get; set; }
        public int Status { get; set; }
        [ForeignKey("MenuID")]
        public int MenuID { get; set; }
        public Menu? Menu { get; set; }
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}