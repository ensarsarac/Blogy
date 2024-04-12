using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.CategoryDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _categoryService.TGetAllList();
            var result = _mapper.Map<List<GetCategoryList>>(values);
            return View(result);
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id) {
            var value = _categoryService.TGetById(id);
            var result = _mapper.Map<UpdateCategoryDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryDto model)
        {
            var value = _mapper.Map<Category>(model);
            _categoryService.TUpdate(value);
            return RedirectToAction("Index");
        }
    
        
        public IActionResult CreateCategory(string name)
        {
            var value = new Category { Name = name };
            _categoryService.TAdd(value);
            return RedirectToAction("Index");
        }

		public IActionResult RemoveCategory(int id)
		{
			_categoryService.TRemove(id);
			return RedirectToAction("Index");
		}

	}
}
