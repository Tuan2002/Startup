using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Startup.Data;
using Startup.Models;

namespace Startup.Components
{
    [ViewComponent(Name = "PostList")]
    public class PostList : ViewComponent
    {
        private readonly StartupDBContext _context;
        public PostList(StartupDBContext context)
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
                select new PostViewModel
                {
                    PostID = post.PostID,
                    Title = post.Title,
                    Abstract = post.Abstract,
                    Author = post.Author,
                    CreatedDate = post.CreatedDate,
                    CategoryName = category.CategoryName,
                    Images = post.Images
                }
            ).ToListAsync();
            return await Task.FromResult((IViewComponentResult)View("PostList", posts));
        }
    }
}