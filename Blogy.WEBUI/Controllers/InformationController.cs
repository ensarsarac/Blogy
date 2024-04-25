using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
