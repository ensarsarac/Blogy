using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
    public class _CategoriesCountComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoriesCountComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetAllCategoriesAndCount();
            return View(values);
        }
    }
}
