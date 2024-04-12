using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.AppUserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IAppUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<List<ResultAppUserDto>>(_userService.TGetAllList()));
        }
    }
}
