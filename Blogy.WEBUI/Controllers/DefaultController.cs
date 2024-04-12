using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
