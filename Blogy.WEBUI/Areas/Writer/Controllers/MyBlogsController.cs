using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.ArticleDtos;
using Blogy.DTOLayer.CommentDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize(Roles = "Admin,Writer")]
    public class MyBlogsController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

		public MyBlogsController(IArticleService articleService, UserManager<AppUser> userManager, IMapper mapper, ICommentService commentService)
		{
			_articleService = articleService;
			_userManager = userManager;
			_mapper = mapper;
			_commentService = commentService;
		}

		public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticleListByUserId(user.Id);
            var result = _mapper.Map<List<GetArticleByUserIdDto>>(values);
            return View(result);
        }
        public IActionResult BlogComments(int id)
        {
            var values = _commentService.TGetCommentListWithUser(id);
            var result = values.Select(x => new ResultCommentDto
            {
                CommentID = x.CommentID,
                Date=x.CommentDate,
                Message=x.Content,
                UserImage=x.AppUser.ImageUrl,
                UserNameSurname=x.AppUser.Name+" "+x.AppUser.Surname,
            }).ToList();
            return View(result);

		}
    }
}
