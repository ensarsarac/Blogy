using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.ValidationRules.AboutValidator;
using Blogy.DTOLayer.AboutDtos;
using Blogy.DTOLayer.CategoryDtos;
using Blogy.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
	[Area("Admin")]
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
			var values = _aboutService.TGetAllList();
			var result = _mapper.Map<List<ResultAboutDto>>(values);
			return View(result);
		}
		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto model)
		{
			CreateAboutDtoValidator validationRules = new CreateAboutDtoValidator();
			ValidationResult validationResult = validationRules.Validate(model);
			if (validationResult.IsValid)
			{
				var result = _mapper.Map<About>(model);
				_aboutService.TAdd(result);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(model);

		}
	
		public IActionResult RemoveAbout(int id)
		{
			_aboutService.TRemove(id);
			return RedirectToAction("Index");
		}
		public IActionResult UpdateAbout(int id)
		{
			var result = _mapper.Map<UpdateAboutDto>(_aboutService.TGetById(id));	
			return View(result);
		}
		[HttpPost]
		public IActionResult UpdateAbout(UpdateAboutDto model)
		{
			UpdateAboutDtoValidator validationRules = new UpdateAboutDtoValidator();
			ValidationResult validationResult = validationRules.Validate(model);
			if (validationResult.IsValid)
			{
				var result = _mapper.Map<About>(model);
				_aboutService.TUpdate(result);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(model);
		}
	}
}
