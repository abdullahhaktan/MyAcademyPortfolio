using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutSideBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
