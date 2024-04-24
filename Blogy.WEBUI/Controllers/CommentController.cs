using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.UnitOfWork;
using Blogy.DTOLayer.CommentDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blogy.WEBUI.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto model)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            _commentService.TAdd(new Comment()
            {
                AppUserID = currentUser.Id,
                ArticleID = model.ArticleID,
                Content = model.Message,
                CommentDate = DateTime.Now,
            });

            return RedirectToAction("BlogDetails", "Blogs", new { @id = model.ArticleID });
        }

    }
}
