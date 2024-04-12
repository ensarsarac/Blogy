using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.UILayoutComponents
{
	public class _MobileMenuComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
