using Blogy.DataAccessLayer.Context;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MyStatisticController : Controller
    {
        private readonly BlogyContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MyStatisticController(BlogyContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
    }
}
