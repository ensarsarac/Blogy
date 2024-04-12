using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.DTOLayer.SendMessageDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SendMessageController : Controller
	{
		private readonly ISendMessageService _sendService;
		private readonly IMapper _mapper;

		public SendMessageController(ISendMessageService sendService, IMapper mapper)
		{
			_sendService = sendService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var result = _mapper.Map<List<ResultSendMessageDto>>(_sendService.TGetListOrderBy());
			return View(result);
		}
		public IActionResult RemoveSendMessage(int id)
		{
			_sendService.TRemove(id);
			return RedirectToAction("Index");
		}
	}
}
