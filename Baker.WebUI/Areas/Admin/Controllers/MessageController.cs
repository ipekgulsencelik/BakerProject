using AutoMapper;
using Baker.DataAccessLayer.Repository.Abstract;
using Baker.DTO.DTOs.MessageDTOs;
using Baker.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class MessageController : Controller
	{
		private readonly IMongoGenericRepository<Message> _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMongoGenericRepository<Message> messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _messageService.GetAllAsync();
			var values = _mapper.Map<List<ResultMessageDTO>>(result);
			return View(values);
		}

		public async Task<IActionResult> DeleteMessage(string id)
		{
			await _messageService.DeleteAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> MessageDetails(string id)
		{
			var message = await _messageService.GetByIdAsync(id);
			var value = _mapper.Map<ResultMessageDTO>(message);
			return View(value);
		}
	}
}