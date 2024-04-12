using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.UILayoutComponents
{
	public class _LoaderComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
