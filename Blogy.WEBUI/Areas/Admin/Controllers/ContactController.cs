using AutoMapper;
using Blogy.BusinessLayer.Abstract;
using Blogy.BusinessLayer.ValidationRules.ContactValidator;
using Blogy.DTOLayer.ContactDtos;
using Blogy.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WEBUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var value = _mapper.Map<List<ResultContactList>>(_contactService.TGetAllList());
			return View(value);
		}
		public IActionResult RemoveContact(int id)
		{
			_contactService.TRemove(id);
			return RedirectToAction("Index");
		}
		public IActionResult CreateContact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDto model)
		{
			CreateContactValidator validationRules = new CreateContactValidator();
			ValidationResult result = validationRules.Validate(model);	
			if(result.IsValid)
			{
				var contact = _mapper.Map<ContactInfo>(model);
				_contactService.TAdd(contact);
				return RedirectToAction("Index");
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

		public IActionResult UpdateContact(int id)
		{
			var value = _mapper.Map<UpdateContactDto>(_contactService.TGetById(id));
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateContact(UpdateContactDto model)
		{
			UpdateContactValidator validationRules = new UpdateContactValidator();
			ValidationResult result = validationRules.Validate(model);
			if(result.IsValid) {
				var value = _mapper.Map<ContactInfo>(model);
				_contactService.TUpdate(value);
				return RedirectToAction("Index");
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
