using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Startup.Data;
using Startup.Models;

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
                select new MenuViewModel
                {
                    MenuID = menu.MenuID,
                    MenuName = menu.MenuName,
                    ControllerName = menu.ControllerName,
                    ActionName = menu.ActionName,
                    IsActive = menu.IsActive,
                    Levels = menu.Levels,
                    ParentID = menu.ParentID,
                    MenuOrder = menu.MenuOrder,
                    Link = menu.Link,
                    Position = menu.Position
                }
            ).ToListAsync();
            return await Task.FromResult((IViewComponentResult)View("Navbar", menus));
        }
    }
}