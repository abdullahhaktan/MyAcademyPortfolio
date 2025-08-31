using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
