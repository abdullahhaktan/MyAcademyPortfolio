using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default___Index
{
    public class _DefaultStatisticComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.projectCount = context.Projects.Count();
            
            var value1 = context.Skills.Any() ? context.Skills.Average(x => x.Percentage).ToString("00.00") : 0.0.ToString("00.00");

            ViewBag.skillAverage = (int)double.Parse(value1);

            ViewBag.unreadMessageCount = context.UserMessages.Count(x => x.IsRead == false);
            
            
            ViewBag.lastMessageOwner = context.UserMessages.OrderByDescending(x => x.UserMessageId).Select(x => x.Name).FirstOrDefault();


            int totalYears = context.Experiences.Where(e => e.EndYear != "Devam Ediyor").Sum(e => Convert.ToInt32(e.EndYear) - e.StartYear);

            int totalYears1 = context.Experiences.Where(e => e.EndYear == "Devam Ediyor").Sum(e => DateTime.Now.Year - e.StartYear);

            int experienceYear = totalYears + totalYears1;

            ViewBag.experienceYear = experienceYear;

            ViewBag.companyCount = context.Experiences.Select(x => x.Company).Distinct().Count();

            var value = context.Testimonials.Any() ? context.Testimonials.Average
                (x => x.Review).ToString("0.0") : "Değerlendirme Yapılmadı";



            ViewBag.reviewAverage = (value != "Değerlendirme Yapılmadı" ? (object)(int)double.Parse(value) : "Degerlendirme yapılmadı");

            ViewBag.maxReviewOwner = context.Testimonials.OrderByDescending(x => x.Review).Select(x => x.Name).FirstOrDefault();

            ViewBag.skillCount = context.Skills.Count();

            ViewBag.HighSkills = context.Skills.Where(x => x.Percentage > 75).Count();

            ViewBag.projectCount = context.Projects.Count();

            ViewBag.mostProjectCategory = context.Projects.
                GroupBy(p => new { p.CategoryId, p.Category.CategoryName })
                .Select(g => new
                {
                    CategoryId = g.Key.CategoryId,
                    CategoryName = g.Key.CategoryName,
                    ProjectCount = g.Count()
                })
                .OrderByDescending(g => g.ProjectCount)
                .Select(g => g.CategoryName)
                .FirstOrDefault();

            return View();
        }
    }
}
