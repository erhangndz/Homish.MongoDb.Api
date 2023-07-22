using Microsoft.AspNetCore.Mvc;

namespace Homish.ApiConsume.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
