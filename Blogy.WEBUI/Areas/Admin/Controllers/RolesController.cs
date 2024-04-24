using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.AppRoleDtos;
using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IAppRoleService _roleService;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

		public RolesController(IAppRoleService roleService, IMapper mapper, RoleManager<AppRole> roleManager)
		{
			_roleService = roleService;
			_mapper = mapper;
			_roleManager = roleManager;
		}

		public IActionResult Index()
        {
            var values = _roleService.TGetAllList();
            var result = _mapper.Map<List<ResultAppRoleDto>>(values);
            return View(result);
        }
        [HttpPost]
        public IActionResult CreateRole(CreateAppRoleDto createAppRoleDto)
        {
            var mapper = _mapper.Map<AppRole>(createAppRoleDto);
            _roleService.TAdd(mapper);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveRole(int id)
        {
            _roleService.TRemove(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleService.TGetById(id);
            var result = _mapper.Map<UpdateAppRoleDto>(value);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateRole(UpdateAppRoleDto updateAppRoleDto)
        {
            var result = _roleService.TGetById(updateAppRoleDto.Id);
            result.Name = updateAppRoleDto.Name;
            _roleService.TUpdate(result);
            return RedirectToAction("Index");
        }
    }
}
