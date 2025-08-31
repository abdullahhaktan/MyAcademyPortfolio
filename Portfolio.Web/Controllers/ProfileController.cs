using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.ComponentModel.Design;

namespace Portfolio.Web.Controllers
{
    public class ProfileController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var value = context.Users.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(User user , string Password1,string Password2)
        {
            var password = context.Users.Where(u=>u.UserId == user.UserId).Select(u=>u.Password).FirstOrDefault();

            if(password==user.Password)
            {
                if(Password1 == Password2)
                {
                    user.Password = Password1;
                    context.Users.Update(user);
                    context.SaveChanges();
                }
                else
                {
                    TempData["message"] = "Şifreler uyuşmuyor";
                }
            }
            else
            {
                TempData["message"] = "Mevcut şifreniz doğru değil!";
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}
