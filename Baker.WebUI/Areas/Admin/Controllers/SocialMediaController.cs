using AutoMapper;
using Baker.BusinessLayer.Validations.SocialMediaValidations;
using Baker.DataAccessLayer.Repository.Abstract;
using Baker.DTO.DTOs.SocialMediaDTOs;
using Baker.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class SocialMediaController : Controller
	{
		private readonly IMongoGenericRepository<SocialMedia> _accountService;
		private readonly IMapper _mapper;

		public SocialMediaController(IMapper mapper, IMongoGenericRepository<SocialMedia> accountService)
		{
			_mapper = mapper;
			_accountService = accountService;
		}

		public async Task<IActionResult> Index()
		{
			var accounts = await _accountService.GetAllAsync();
			var values = _mapper.Map<List<ResultSocialMediaDTO>>(accounts);
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateSocialMediaDTO createSocialMediaDTO)
		{
			createSocialMediaDTO.CreatedAt = DateTime.Now;

			ModelState.Clear();
			var account = _mapper.Map<SocialMedia>(createSocialMediaDTO);
			var validator = new SocialMediaValidator();
			var result = await validator.ValidateAsync(account);
			if (!result.IsValid)
			{
				result.Errors.ForEach(x =>
				{
					ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
				});
				return View();
			}
			await _accountService.CreateAsync(account);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(string id)
		{
			await _accountService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSocialMedia(string id)
		{
			var account = await _accountService.GetByIdAsync(id);
			var value = _mapper.Map<UpdateSocialMediaDTO>(account);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO)
		{
			updateSocialMediaDTO.CreatedAt = DateTime.Now;

			var account = _mapper.Map<SocialMedia>(updateSocialMediaDTO);
			await _accountService.UpdateAsync(account);
			return RedirectToAction(nameof(Index));
		}
	}
}