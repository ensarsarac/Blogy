using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.ValidationRules.SendMessageValidator;
using Blogy.DTOLayer.SendMessageDtos;
using Blogy.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly ISendMessageService _messageService;
		private readonly IMapper _mapper;

		public ContactController(ISendMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(SendMessageDto model)
		{
			SendMessageValidation validationRules = new SendMessageValidation();
			ValidationResult result = validationRules.Validate(model);
			if (result.IsValid)
			{
				var value = _mapper.Map<SendMessage>(model);
				_messageService.TAdd(value);
				return RedirectToAction("Index", "Default");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(model);
		}
	}
}
