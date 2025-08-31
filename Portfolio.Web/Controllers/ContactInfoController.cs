using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ContactInfoController(PortfolioContext context) : Controller
    {

        public IActionResult Index()
        {
            var categories = context.ContactInfos.ToList();
            return View(categories);
        }
         
        [HttpGet]
        public IActionResult CreateContactInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContactInfo(ContactInfo contactInfo)
        {
            context.ContactInfos.Add(contactInfo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContactInfo(int id)
        {
            var contactInfo = context.ContactInfos.Find(id);
            context.ContactInfos.Remove(contactInfo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateContactInfo(int id)
        {
            var contactInfo = context.ContactInfos.Find(id);
            return View(contactInfo);
        }

        [HttpPost]
        public IActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            context.Update(contactInfo);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
