using AutoMapper;
using Baker.BusinessLayer.Validations.CarouselValidations;
using Baker.DataAccessLayer.Repository.Abstract;
using Baker.DTO.DTOs.CarouselDTOs;
using Baker.DTO.DTOs.SubscribeDTOs;
using Baker.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class CarouselController : Controller
	{
		private readonly IMongoGenericRepository<Carousel> _carouselService;
		private readonly IMapper _mapper;

		public CarouselController(IMapper mapper, IMongoGenericRepository<Carousel> carouselService)
		{
			_mapper = mapper;
			_carouselService = carouselService;
		}

		public async Task<IActionResult> Index()
		{
			var carouselList = await _carouselService.GetAllAsync();
			var values = _mapper.Map<List<ResultSubscribeDTO>>(carouselList);
			return View(values);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCarouselDTO createCarouselDTO)
		{
			ModelState.Clear();
			var carousel = _mapper.Map<Carousel>(createCarouselDTO);

			var validator = new CarouselValidator();
			var result = await validator.ValidateAsync(carousel);
			if (!result.IsValid)
			{
				result.Errors.ForEach(x =>
				{
					ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
				});
				return View();
			}
			await _carouselService.CreateAsync(carousel);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(string id)
		{
			await _carouselService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			var result = await _carouselService.GetByIdAsync(id);
			var value = _mapper.Map<UpdateCarouselDTO>(result);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateCarouselDTO updateCarouselDTO)
		{
			var carousel = _mapper.Map<Carousel>(updateCarouselDTO);
			await _carouselService.UpdateAsync(carousel);
			return RedirectToAction(nameof(Index));
		}
	}
}