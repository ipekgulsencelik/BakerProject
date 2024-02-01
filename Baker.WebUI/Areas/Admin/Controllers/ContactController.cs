using Baker.WebUI.CQRS.Commands.ContactCommands;
using Baker.WebUI.CQRS.Handlers.ContactHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{

	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class ContactController : Controller
	{
		private readonly GetContactQueryHandler _getContactQueryHandler;
		private readonly CreateContactCommandHandler _createContactCommandHandler;
		private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
		private readonly UpdateContactCommandHandler _updateContactCommandHandler;

		public ContactController(GetContactQueryHandler getContactQueryHandler, CreateContactCommandHandler createContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, UpdateContactCommandHandler updateContactCommandHandler)
		{
			_getContactQueryHandler = getContactQueryHandler;
			_createContactCommandHandler = createContactCommandHandler;
			_getContactByIdQueryHandler = getContactByIdQueryHandler;
			_updateContactCommandHandler = updateContactCommandHandler;
		}

		public IActionResult Index()
		{
			var value = _getContactQueryHandler.Handle();

			if (value.ContactID == null)
				ViewBag.flag = false;
			else
				ViewBag.flag = true;

			ViewBag.id = value.ContactID;
			ViewBag.header = value.Title;
			ViewBag.address = value.Address;
			ViewBag.phone = value.PhoneNumber;
			ViewBag.mail = value.EmailAddress;
			ViewBag.createdAt = value.CreatedAt;
			ViewBag.status = value.Status;
						
			return View();
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactCommand command)
		{
			command.CreatedAt = DateTime.Now;
			command.Status = true;

			_createContactCommandHandler.Handle(command);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateContact()
		{
			var value = _getContactQueryHandler.Handle();
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateContact(UpdateContactCommand command)
		{
			command.CreatedAt = DateTime.Now;
			command.Status = true;

			_updateContactCommandHandler.Handle(command);
			return RedirectToAction("Index");
		}
	}
}