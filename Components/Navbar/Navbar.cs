using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Startup.Data;

namespace Startup.Components
{
    [ViewComponent(Name = "Navbar")]
    public class Navbar : ViewComponent
    {
        private readonly StartupDBContext _context;
        public Navbar(StartupDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menus = await (
                from menu in _context.Menu
                where menu.IsActive == true
                orderby menu.MenuOrder
                select menu
            ).ToListAsync();
            return await Task.FromResult((IViewComponentResult)View("Navbar", menus));
        }
    }
}