using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SocialMediaController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            if (value != null)
            {
                context.SocialMedias.Remove(value);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            var deger = "";
            if (socialMedia.Name.ToLower() == "instagram")
            {
                deger = "fa-brands fa-instagram";
            }
            else if (socialMedia.Name.ToLower() == "linkedin")
            {
                deger = "fa-brands fa-linkedin";
            }
            else if (socialMedia.Name.ToLower() == "github")
            {
                deger = "fa-brands fa-github";
            }
            else
            {
                return View(socialMedia);
            }

            context.SocialMedias.Add(socialMedia);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = context.SocialMedias.Find(id);
            return View(socialMedia);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedias.Update(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
