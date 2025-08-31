using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.Default___Index
{
    public class _DefaultSendMessageComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
