using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
	[Area("Writer")]
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
