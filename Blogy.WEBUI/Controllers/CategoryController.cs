using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.DTOLayer.CategoryDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Blogy.WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int id, int page = 1, int pageSize = 4)
        {
            var values = _categoryService.TGetCategoryListById(id);
            var result = values.Select(x => new GetCategoryListByIdDto()
            {
                ArticleID = x.ArticleID,
                Content = x.Content,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                CategoryName = x.Category.Name,
            }).ToList().ToPagedList(page,pageSize);
            ViewBag.category = _categoryService.TGetById(id);
            return View(result);
        }
      

    }
}
