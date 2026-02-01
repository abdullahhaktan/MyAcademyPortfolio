using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    //[Authorize] // Currently commented out - would require authentication if enabled
    public class StatisticsController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            // Count total projects
            ViewBag.projectCount = context.Projects.Count();

            // Calculate average skill percentage with null check
            ViewBag.skillAverage = context.Skills.Any() ?
                context.Skills.Average(x => x.Percentage).ToString("00.00") :
                0.0.ToString("00.00");

            // Count unread messages
            ViewBag.unreadMessageCount = context.UserMessages.Count(x => x.IsRead == false);

            // Get name of sender for most recent message
            ViewBag.lastMessageOwner = context.UserMessages.OrderByDescending(x => x.UserMessageId)
                .Select(x => x.Name).FirstOrDefault();

            // Calculate total years of experience (excluding current positions)
            int totalYears = context.Experiences.Where(e => e.EndYear != "Devam Ediyor")
                .Sum(e => Convert.ToInt32(e.EndYear) - e.StartYear);

            // Calculate years for current/ongoing positions
            int totalYears1 = context.Experiences.Where(e => e.EndYear == "Devam Ediyor")
                .Sum(e => DateTime.Now.Year - e.StartYear);

            int experienceYear = totalYears + totalYears1; // Combine both totals
            ViewBag.experienceYear = experienceYear;

            // Count distinct companies worked for
            ViewBag.companyCount = context.Experiences.Select(x => x.Company).Distinct().Count();

            // Calculate average review rating with null check
            ViewBag.reviewAverage = context.Testimonials.Any() ?
                context.Testimonials.Average(x => x.Review).ToString("0.0") :
                "Değerlendirme Yapılmadı";

            // Get name of person who gave the highest review
            ViewBag.maxReviewOwner = context.Testimonials.OrderByDescending(x => x.Review)
                .Select(x => x.Name).FirstOrDefault();

            // Count total skills
            ViewBag.skillCount = context.Skills.Count();

            // Count skills with percentage above 75 (high proficiency)
            ViewBag.HighSkills = context.Skills.Where(x => x.Percentage > 75).Count();

            // Count total projects (repeated - same as first line)
            ViewBag.projectCount = context.Projects.Count();

            // Find category with most projects using grouping
            ViewBag.mostProjectCategory = context.Projects
                .GroupBy(p => new { p.CategoryId, p.Category.CategoryName }) // Group by category
                .Select(g => new
                {
                    CategoryId = g.Key.CategoryId,
                    CategoryName = g.Key.CategoryName,
                    ProjectCount = g.Count() // Count projects in each category
                })
                .OrderByDescending(g => g.ProjectCount) // Sort by project count descending
                .Select(g => g.CategoryName) // Select category name
                .FirstOrDefault(); // Get top category

            return View();
        }
    }
}