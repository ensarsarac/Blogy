using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.UnitOfWork;
using Blogy.DTOLayer.ArticleDtos;
using Blogy.DTOLayer.CommentDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Blogy.WEBUI.Controllers
{
	public class BlogsController : Controller
	{
		private readonly IArticleService _articleService;
		private readonly ICommentService _commentService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IUowDal _uowDal;

        public BlogsController(IArticleService articleService, ICommentService commentService, UserManager<AppUser> userManager, IUowDal uowDal)
        {
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
            _uowDal = uowDal;
        }

        public IActionResult Index(int page=1,int pageSize=6)
		{
			var values = _articleService.TGetBlogListWithCategory();
			var result = values.Select(x => new GetArticleBlogPageDto()
			{
				CategoryName = x.Category.Name,
				Content = x.Content,
				Date = x.CreatedDate,
				Id = x.ArticleID,
				ImageUrl = x.CoverImageUrl,
				Title = x.Title,

			}).ToList().ToPagedList(page,pageSize);
			return View(result);
		}
		
		public IActionResult BlogDetails(int id)
		{
			var value = _articleService.TGetArticleByIdWithCategoryAndUser(id);
			GetArticleByIdDto model = new GetArticleByIdDto();
			model.Title = value.Title;
			model.Content = value.Content;
			model.CreatedDate = value.CreatedDate;
			model.CoverImageUrl = value.CoverImageUrl;
			model.Name=value.Category.Name;
			model.NameSurname = value.AppUser.Name + " " + value.AppUser.Surname;
			model.ArticleID = value.ArticleID;
			model.UserImageUrl = value.AppUser.ImageUrl;
			model.UserDescription = value.AppUser.Description;
			TempData["id"] = id;
			return View(model);
		}

		[HttpGet]
		public IActionResult GetCommentList()
		{
			int id = (int)TempData["id"];
			var values = _commentService.TGetCommentListWithUser(id);
			var result = values.Select(x => new ResultCommentDto()
			{
				CommentID = x.CommentID,
				Date=x.CommentDate,
				Message=x.Content,
				UserImage=x.AppUser.ImageUrl,
				UserNameSurname=x.AppUser.Name+" "+x.AppUser.Surname,
			}).ToList();
			var jsonData = JsonConvert.SerializeObject(result);
			return Json(jsonData);
		}

	


	}
}
