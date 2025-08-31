using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default___Index
{
    public class _DefaultProjectsComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categoriesWithProjects = context.Categories.Include(c => c.Projects).ToList();
            return View(categoriesWithProjects);
        }
    }
}
