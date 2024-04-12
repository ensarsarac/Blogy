using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.TagsDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.ViewComponents.DefaultComponents
{
    public class _TagsComponent:ViewComponent
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public _TagsComponent(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _tagService.TGetAllList();
            var mapperValues = _mapper.Map<List<GetTagDto>>(values);
            return View(mapperValues);
        }
    }
}
