using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.AppUserDtos;
using Blogy.DTOLayer.ArticleDtos;
using Blogy.DTOLayer.CommentDtos;
using Blogy.EntityLayer.Concrete;
using Blogy.WEBUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager; 
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

		public UsersController(IAppUserService userService, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IArticleService articleService, ICommentService commentService)
		{
			_userService = userService;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
			_articleService = articleService;
			_commentService = commentService;
		}

		public IActionResult Index()
        {
            return View(_mapper.Map<List<ResultAppUserDto>>(_userService.TGetAllList()));
        }
        public async Task<IActionResult> AddRole(int id)
        {
            var user = _userManager.Users.Where(x=>x.Id == id).FirstOrDefault();
            TempData["userid"] = user.Id;
            var roles =await _userManager.GetRolesAsync(user);
            List<RolesViewModel> rolesViewModels = new List<RolesViewModel>();
            foreach (var role in _roleManager.Roles.ToList()) 
            {
                RolesViewModel rolesViewModel = new RolesViewModel();
                rolesViewModel.Id = role.Id;
                rolesViewModel.Name = role.Name;
                rolesViewModel.IsExist = roles.Contains(role.Name);
                rolesViewModels.Add(rolesViewModel);
            }
            return View(rolesViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(List<RolesViewModel> models)
        {
            var id = (int)TempData["userid"];
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            foreach (var item in models)
            {
                if (item.IsExist)
                {
                    await _userManager.AddToRoleAsync(user,item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult UserBlogs(int id)
        {
            TempData["userblogid"] = id;
            var values = _articleService.TGetArticleListByUserId(id);
            var result = values.Select(x => new GetArticleByUserIdDto
            {
                ArticleId = x.ArticleID,
                CategoryName = x.Category.Name,
                Date=x.CreatedDate,
                NameSurname=x.AppUser.Name+" "+x.AppUser.Surname,
                Title = x.Title,
                UserImageUrl = x.AppUser.ImageUrl,
            }).ToList();
            return View(result);
        }
		public IActionResult RemoveArticle(int id)
		{
            var userblogsid = (int)TempData["userblogid"];
            _articleService.TRemove(id);
            return RedirectToAction("UserBlogs", new {id=userblogsid});
		}
	    
        public IActionResult UserComments(int id)
        {
            TempData["commentid"] = id;
            var values = _commentService.TCommentListByUserId(id);
            var result = values.Select(x => new CommentListByUserIdDto
            {
                ArticleTitle=x.Article.Title,
                CommentId=x.CommentID,
                Content=x.Content,
                Date=x.CommentDate,
                UserImageUrl=x.AppUser.ImageUrl,
                UserNameSurname=x.AppUser.Name+" "+x.AppUser.Surname,
            }).ToList();
            return View(result);
        }
		public IActionResult RemoveComment(int id)
		{
			var commentid = (int)TempData["commentid"];
            _commentService.TRemove(id);
			return RedirectToAction("UserComments", new { id = commentid });
		}

	}
}
