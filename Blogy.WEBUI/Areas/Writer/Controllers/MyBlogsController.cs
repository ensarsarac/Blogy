using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.ArticleDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MyBlogsController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public MyBlogsController(IArticleService articleService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _articleService = articleService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticleListByUserId(user.Id);
            var result = _mapper.Map<List<GetArticleByUserIdDto>>(values);
            return View(result);
        }
    }
}
