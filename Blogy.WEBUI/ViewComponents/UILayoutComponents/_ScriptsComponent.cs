using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.UILayoutComponents
{
	public class _ScriptsComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
