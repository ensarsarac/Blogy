using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
	public class _FooterSocialMediaComponent:ViewComponent
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public _FooterSocialMediaComponent(IMapper mapper, ISocialMediaService socialMediaService)
		{
			_mapper = mapper;
			_socialMediaService = socialMediaService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAllList());
			return View(result);
		}
	}
}
