using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.ViewComponents.Summary
{
    [ViewComponent(Name = "summary")]
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
