using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ReportController : Controller
	{
		private readonly IArticleService _articleService;

		public ReportController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IActionResult Index()
		{
			return View(_articleService.TGetBlogListWithCategoryAndUser());
		}
	}
}
