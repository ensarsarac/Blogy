using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Blogy.WEBUI.Areas.Writer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MyDashboardController : Controller
    {
        private readonly BlogyContext _blogContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogyContext _context;

        public MyDashboardController(BlogyContext blogContext, UserManager<AppUser> userManager, BlogyContext context)
        {
            _blogContext = blogContext;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.blogcount = _context.Articles.Where(x => x.AppUserID == user.Id).ToList().Count();
            ViewBag.commentcount = _context.Comments.Where(x => x.AppUserID == user.Id).ToList().Count();
            ViewBag.incomingmessagecount = _context.Messages.Where(x => x.ReceiverUserId == user.Id).ToList().Count();
            ViewBag.sendmessagecount = _context.Messages.Where(x => x.SenderUserId == user.Id).ToList().Count();
            return View();
        }
        public async Task<IActionResult> GetChart()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _blogContext.Comments.Where(x => x.AppUserID == user.Id).GroupBy(x => x.ArticleID).Select(y => new MyBlogAndCommentViewModel
            {
                blogname = _blogContext.Articles.Where(x=>x.ArticleID==y.Key).Select(z=>z.Title).FirstOrDefault(),
                commentcount=y.Count(),
            }).ToList();
            return Json(new {jsonlist=values});
        }
    }
}
