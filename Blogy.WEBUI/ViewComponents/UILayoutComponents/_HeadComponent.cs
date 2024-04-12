using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.UILayoutComponents
{
	public class _HeadComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
