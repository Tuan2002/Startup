using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Startup.Data;
using Startup.Models;

namespace Startup.Components
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryList : ViewComponent
    {
        private readonly StartupDBContext _context;
        private readonly ILogger<CategoryList> _logger;
        public CategoryList(StartupDBContext context, ILogger<CategoryList> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var categories = await (
                    from category in _context.Category
                    select category
                ).ToListAsync();
                return await Task.FromResult((IViewComponentResult)View("CategoryList", categories));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error!");
                return await Task.FromResult((IViewComponentResult)View("CategoryList", new Category[] { }));
            }
        }
    }
}