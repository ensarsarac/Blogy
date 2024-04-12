using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.ValidationRules.ArticleValidator;
using Blogy.DataAccessLayer.Context;
using Blogy.DTOLayer.ArticleDtos;
using Blogy.DTOLayer.BlogDtos;
using Blogy.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class BlogsController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public BlogsController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogList(int page=1, int pageSize=5)
        {            
            var values = _articleService.TGetBlogListWithCategoryAndUser().ToPagedList(page,pageSize);
            return View(values);
        }
        public IActionResult RemoveBlog(int id)
        {
            _articleService.TRemove(id);
            return RedirectToAction("BlogList");

        }
        public IActionResult UpdateBlog(int id)
        {
            var value = _articleService.TGetById(id);
            AdminArticleGetById model = new AdminArticleGetById()
            {
                CategoryId = value.CategoryID,
                Description=value.Content,
                Id=value.ArticleID,
                Title =value.Title,
            };
            ViewBag.values = new SelectList(_categoryService.TGetAllList(), "CategoryID", "Name");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(AdminArticleGetById model)
        {
            UpdateArticleDtoValidator validator = new UpdateArticleDtoValidator();
            ValidationResult result = validator.Validate(model);
            var value = _articleService.TGetById(model.Id);
            if (result.IsValid)
            {
                if (model.ImageUrl != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);
                    await model.ImageUrl.CopyToAsync(stream);
                    value.CoverImageUrl = imagename;
                }
                value.Title = model.Title;
                value.Content = model.Description;
                value.CategoryID = model.CategoryId;
                _articleService.TUpdate(value);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ViewBag.values = new SelectList(_categoryService.TGetAllList(), "CategoryID", "Name");
            return RedirectToAction("BlogList");
        }
        public IActionResult CreateBlog()
		{
            ViewBag.values = new SelectList(_categoryService.TGetAllList(),"CategoryID","Name");
            return View();
		}
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Article article = new Article();
            CreateBlogDtoValidator validationRules = new CreateBlogDtoValidator();
            ValidationResult result = validationRules.Validate(model);
            if(result.IsValid)
            {
                if (model.ImageUrl != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = resource + "/wwwroot/BlogImages/" + imagename;
                    var stream = new FileStream(savelocation, FileMode.Create);
                    await model.ImageUrl.CopyToAsync(stream);
                    article.CoverImageUrl = imagename;
                }
                article.Title = model.Title;
                article.Content = model.Content;
                article.CategoryID = model.CategoryID;
                article.CreatedDate = DateTime.Now;
                article.AppUserID = user.Id;
                article.Status = true;
                _articleService.TAdd(article);
                return RedirectToAction("BlogList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            ViewBag.values = new SelectList(_categoryService.TGetAllList(), "CategoryID", "Name");
            return View(model);
        }
    }
}
