using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var result = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetAllList());
			return View(result);
		}
	}
}
