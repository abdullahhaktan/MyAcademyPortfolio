using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default___Index
{
    public class _DefaultAboutComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultAboutComponent(PortfolioContext portfoliContext)
        {
            _context = portfoliContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Abouts.ToList().FirstOrDefault();
            return View(values);
        }
    }
}
