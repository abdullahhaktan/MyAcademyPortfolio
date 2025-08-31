using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default___Index
{
    public class _DefaultResumeComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.user = context.Banners.Select(a => a.NameSurname).FirstOrDefault();
            ViewBag.city = context.Abouts.Select(a=>a.City).FirstOrDefault();
            ViewBag.phone = context.Abouts.Select(a => a.PhoneNumber).FirstOrDefault();
            ViewBag.mail = context.Abouts.Select(a=>a.Email).FirstOrDefault();

            var eduacationExperience = context.Educations.ToList();

            ViewBag.educationExperience = eduacationExperience;

            var experiences = context.Experiences.ToList();

            return View(experiences);
        }
    }
}
