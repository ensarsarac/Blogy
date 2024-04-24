using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.NotificationDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Writer.ViewComponents
{
    public class _WriterLayoutNotificationComponent:ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public _WriterLayoutNotificationComponent(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var result = _mapper.Map<List<GetNotificationDto>>(_notificationService.TGetAllList());
            return View(result);
        }
    }
}
