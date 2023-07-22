using Microsoft.AspNetCore.Mvc;

namespace Homish.ApiConsume.ViewComponents.About
{
    public class _Team:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
