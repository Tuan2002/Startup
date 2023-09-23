using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Startup.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        [MaxLength(50)]
        public string? MenuName { get; set; }
        [MaxLength(50)]
        public string? ControllerName { get; set; }
        [MaxLength(50)]
        public string? ActionName { get; set; }
        public bool? IsActive { get; set; }
        public int? Levels { get; set; }
        public int? ParentID { get; set; }
        public int? MenuOrder { get; set; }
        [MaxLength(50)]
        public string? Link { get; set; }
        public int? Position { get; set; }

    }


}