using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class InboxController : Controller
    {
        private readonly PortfolioContext _context;

        public InboxController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.UserMessages.ToList();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var message = _context.UserMessages.Find(id);
            if (message == null) return NotFound();

            _context.UserMessages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ChangeToRead(int id)
        {
            var message = _context.UserMessages.FirstOrDefault(x => x.UserMessageId == id);

            message.IsRead = true;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
