using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
	[Area("Writer")]
	[Authorize(Roles ="Admin,Writer")]
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
            return View();
		}
	}
}
