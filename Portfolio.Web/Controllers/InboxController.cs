using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System.Reflection.Metadata.Ecma335;

namespace Portfolio.Web.Controllers
{
    public class InboxController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var values = context.UserMessages.ToList();
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            var message = context.UserMessages.Find(id);
            return View(message);
        }

        public IActionResult DeleteMessage(int id)
        {
            var message = context.UserMessages.Find(id);
            context.UserMessages.Remove(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
