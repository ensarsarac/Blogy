using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.ValidationRules.SocialMediaValidator;
using Blogy.DTOLayer.SocialMediaDtos;
using Blogy.EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAllList());
            return View(result);
        }
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto model)
        {
            CreateSocialMediaValidator validationRules = new CreateSocialMediaValidator();
            ValidationResult validationResult = validationRules.Validate(model);
            if(validationResult.IsValid)
            {
                var result = _mapper.Map<SocialMedia>(model);
                _socialMediaService.TAdd(result);
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
        public IActionResult RemoveSocialMedia(int id)
        {
            _socialMediaService.TRemove(id);
            return RedirectToAction("Index");
        }
		public IActionResult UpdateSocialMedia(int id)
		{
			var result = _mapper.Map<UpdateSocialMediaDto>(_socialMediaService.TGetById(id));
            return View(result);
		}
        [HttpPost]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto model)
		{
			UpdateSocialMediaValidator validationRules = new UpdateSocialMediaValidator();
			ValidationResult validationResult = validationRules.Validate(model);
            if(validationResult.IsValid)
            {
				var result = _mapper.Map<SocialMedia>(model);
                _socialMediaService.TUpdate(result);
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
