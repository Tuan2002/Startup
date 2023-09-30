using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Startup.Data;

namespace Startup.Components
{
    [ViewComponent(Name = "RecentPost")]
    public class RecentPost : ViewComponent
    {
        private readonly StartupDBContext _context;
        public RecentPost(StartupDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await (
                from post in _context.Post
                where post.IsActive == true && post.Status == 1
                orderby post.PostID descending
                select post
            ).Take(3).ToListAsync();
            return await Task.FromResult((IViewComponentResult)View("RecentPost", posts));
        }
    }
}