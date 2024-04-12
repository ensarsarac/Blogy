using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
	public class _ContactInfoComponent:ViewComponent
	{
		private readonly IContactService _contactService;

		public _ContactInfoComponent(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _contactService.TGetAllList();
			return View(values);
		}
	}
}
