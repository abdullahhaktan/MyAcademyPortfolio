using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
