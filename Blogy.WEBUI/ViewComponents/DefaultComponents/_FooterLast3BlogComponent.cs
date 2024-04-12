using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
	public class _FooterLast3BlogComponent:ViewComponent
	{
		private readonly IArticleService _articleService;
		private readonly IMapper _mapper;

		public _FooterLast3BlogComponent(IArticleService articleService, IMapper mapper)
		{
			_articleService = articleService;
			_mapper = mapper;
		}
		public IViewComponentResult Invoke()
		{
			var result = _mapper.Map<List<Last3BlogDto>>(_articleService.TLastPostList());
			return View(result);
		}
	}
}
