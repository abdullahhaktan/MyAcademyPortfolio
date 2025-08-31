using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class BannerController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var values = context.Banners.FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Banner banner)
        {
            context.Banners.Update(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
