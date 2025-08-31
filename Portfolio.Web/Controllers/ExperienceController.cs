using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var experiences = _context.Experiences.ToList();

            return View(experiences);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var Experience = _context.Experiences.Find(id);
            _context.Experiences.Remove(Experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateExperience(int id)
        {
            var Experience = _context.Experiences.Find(id);
            return View(Experience);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
