using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.CommentDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MyCommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public MyCommentsController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.TCommentListByUserId(user.Id);
            var result = values.Select(x => new CommentListByUserIdDto
            {
                ArticleTitle = x.Article.Title,
                CommentId = x.CommentID,
                Content = x.Content,
                Date = x.CommentDate,
                UserImageUrl = x.AppUser.ImageUrl,
                UserNameSurname = x.AppUser.Name + " " + x.AppUser.Surname,
            }).ToList();
            return View(result);
        }
        public IActionResult DeleteComment(int id)
        {
            _commentService.TRemove(id);
            return RedirectToAction("Index");
        }
    }
}
