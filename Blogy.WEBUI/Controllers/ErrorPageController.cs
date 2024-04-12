using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult NotFound404()
        {
            return View();
        }
    }
}
