using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Startup.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public long PostID { get; set; }
        public string? Title { get; set; }
        [MaxLength(255)]
        public string? Abstract { get; set; }
        [MaxLength(255)]
        public string? Contents { get; set; }
        [MaxLength(255)]
        public string? Images { get; set; }
        [MaxLength(255)]
        public string? Link { get; set; }
        [MaxLength(255)]
        public string? Author { get; set; }
        [MaxLength(50)]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int? PostOrder { get; set; }
        public int? MenuID { get; set; }
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public int Status { get; set; }
    }
}