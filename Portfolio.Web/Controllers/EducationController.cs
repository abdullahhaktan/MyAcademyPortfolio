using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class EducationController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var experiences = context.Educations.ToList();
            return View(experiences);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            context.Educations.Add(education);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEducation(int id)
        {
            var Education = context.Educations.Find(id);
            context.Educations.Remove(Education);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEducation(int id)
        {
            var Education = context.Educations.Find(id);
            return View(Education);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            context.Educations.Update(education);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
