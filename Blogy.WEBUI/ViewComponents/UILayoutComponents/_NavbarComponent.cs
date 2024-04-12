using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WEBUI.ViewComponents.UILayoutComponents
{
	public class _NavbarComponent:ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public _NavbarComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _categoryService.TGetAllList();
			var result = values.Select(x => new NavbarCategoryList()
			{
				CategoryID = x.CategoryID,
				Name=x.Name
			}).ToList();
			return View(result);
		}
	}
}
