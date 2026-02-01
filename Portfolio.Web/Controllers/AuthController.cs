using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Models;
using System.Security.Claims;

namespace Portfolio.Web.Controllers
{
    [AllowAnonymous] // Allow access without authentication
    public class AuthController(PortfolioContext context) : Controller
    {
        // Display login form
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Fast fail - check model validation first
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Find user by username and password (plain text comparison - consider hashing)
            var user = context.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user is null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }

            // Create claims for authenticated user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName), // Standard name claim
                new Claim("fullName",string.Join(" ",user.FirstName,user.LastName)) // Custom full name claim
            };

            // Create claims identity with cookie authentication scheme
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Configure authentication properties
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30), // 30 minute session
                IsPersistent = false, // Session cookie (not persistent)
            };

            // Sign in user - creates authentication cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                     new ClaimsPrincipal(claimsIdentity),
                                     authProperties);

            // Store username in session for quick access
            HttpContext.Session.SetString("UserName", user.UserName);

            // Redirect to statistics dashboard after successful login
            return RedirectToAction("Index", "Statistics");
        }

        // Logout action - clears authentication and session
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserName"); // Clear session
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Sign out
            return RedirectToAction("Index", "Default"); // Redirect to home page
        }
    }
}