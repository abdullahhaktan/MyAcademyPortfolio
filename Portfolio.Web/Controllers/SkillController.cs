using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var skills = _context.Skills.ToList();

            return View(skills);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            return View(skill);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            _context.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
