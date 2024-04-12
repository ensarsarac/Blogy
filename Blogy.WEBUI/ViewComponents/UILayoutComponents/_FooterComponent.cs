using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.UILayoutComponents
{
	public class _FooterComponent:ViewComponent
	{
		private readonly IAboutService aboutService;

		public _FooterComponent(IAboutService aboutService)
		{
			this.aboutService = aboutService;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.about = aboutService.TGetAllList().Take(1).Select(x => x.Description1).FirstOrDefault();
			return View();
		}
	}
}
