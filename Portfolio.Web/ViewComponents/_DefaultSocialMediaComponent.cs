using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents
{
    public class _DefaultSocialMediaComponent:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultSocialMediaComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
    }
}
