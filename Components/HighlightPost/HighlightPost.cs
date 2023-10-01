using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Startup.Data;
using Startup.Models;

namespace Startup.Components
{
    [ViewComponent(Name = "HighlightPost")]
    public class HighlightPost : ViewComponent
    {
        private readonly StartupDBContext _context;
        public HighlightPost(StartupDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await (
                from post in _context.Post
                join category in _context.Category on post.CategoryID equals category.CategoryID
                where post.IsActive == true && post.Status == 1
                orderby post.PostID descending
                select new HighlightPostViewModel
                {
                    PostID = post.PostID,
                    Title = post.Title,
                    Contents = post.Contents,
                    Abstract = post.Abstract,
                    Author = post.Author,
                    CreatedDate = post.CreatedDate,
                    CategoryName = category.CategoryName,
                    Images = post.Images
                }
            ).Take(3).ToListAsync();
            return await Task.FromResult((IViewComponentResult)View("HighlightPost", posts));
        }
    }
}