using Blogy.DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
    {
        private readonly BlogyContext _context;

        public StatisticController(BlogyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.blogCount = _context.Articles.Count();
            ViewBag.userCount = _context.Users.Count();
            ViewBag.categoryCount = _context.Categories.Count();
            ViewBag.messageCount = _context.Messages.Count();
            ViewBag.socialMediaCount = _context.SocialMedias.Count();
            ViewBag.notificationCount = _context.Notifications.Count();
            ViewBag.maxBlogComment = _context.Comments.GroupBy(x => x.ArticleID).Select(x => new
            {
                Key = _context.Articles.Where(y=>y.ArticleID == x.Key).FirstOrDefault().Title,
                Count = x.Count(),
            }).OrderByDescending(x=>x.Count).FirstOrDefault();

            ViewBag.maxBlogCategory= _context.Articles.GroupBy(x => x.CategoryID).Select(x => new
            {
                Key = _context.Categories.Where(y => y.CategoryID == x.Key).FirstOrDefault().Name,
                Count = x.Count(),
            }).OrderByDescending(x => x.Count).FirstOrDefault();

            ViewBag.maxShareBlogUser= _context.Articles.GroupBy(x => x.AppUserID).Select(x => new
            {
                Key = _context.Users.Where(y => y.Id == x.Key).FirstOrDefault().Name,
                Count = x.Count(),
            }).OrderByDescending(x => x.Count).FirstOrDefault();
            return View();
        }
    }
}
