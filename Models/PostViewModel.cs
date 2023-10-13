namespace Startup.Models
{
    public class PostViewModel
    {
        public long PostID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Images { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CategoryName { get; set; }
    }
}