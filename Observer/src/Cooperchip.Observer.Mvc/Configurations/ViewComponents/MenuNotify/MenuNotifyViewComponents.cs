using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Infra.Data;
using Cooperchip.Observer.Mvc.Configurations.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.ViewComponents.MenuNotify
{
    [ViewComponent(Name = "MenuNotify")]
    public class MenuNotifyViewComponents : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public MenuNotifyViewComponents(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Total = Helper.TotalNotify(_context);
            var menuNotify = await _context.Set<Mensagens>().AsNoTracking().OrderByDescending(x => x.Data).Take(12).ToListAsync();

            return View(await Task.FromResult(menuNotify));
        }
    }
}
