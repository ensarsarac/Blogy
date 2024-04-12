using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IAppUserService _appUserService;
        private readonly ICommentService _commentService;

        public DashboardController(IArticleService articleService, IAppUserService appUserService, ICommentService commentService)
        {
            _articleService = articleService;
            _appUserService = appUserService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            ViewBag.ArticleCount = _articleService.TGetAllList().Count();
            ViewBag.UserCount = _appUserService.TGetAllList().Count();
            ViewBag.CommentCount = _commentService.TGetAllList().Count();
            return View();
        }
    }
}
