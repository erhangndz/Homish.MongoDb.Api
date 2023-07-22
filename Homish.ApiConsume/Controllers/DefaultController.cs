using Microsoft.AspNetCore.Mvc;

namespace Homish.ApiConsume.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
