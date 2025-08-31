using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class AboutController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var value = context.Abouts.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            context.Update(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
