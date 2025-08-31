using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default___Index
{
    public class _DefaultTestimonialComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = context.Testimonials.ToList(); 
            return View(values);
        }
    }
}
