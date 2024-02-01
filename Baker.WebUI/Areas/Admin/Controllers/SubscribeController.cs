using AutoMapper;
using Baker.DataAccessLayer.Repository.Abstract;
using Baker.DTO.DTOs.SubscribeDTOs;
using Baker.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SubscribeController : Controller
    {
        private readonly IMongoGenericRepository<Subscribe> _subscribeService;
        private readonly IMapper _mapper;

        public SubscribeController(IMapper mapper, IMongoGenericRepository<Subscribe> subscribeService)
        {
            _mapper = mapper;
            _subscribeService = subscribeService;
        }

        public async Task<IActionResult> Index()
        {
            var subscribeList = await _subscribeService.GetAllAsync();
            var values = _mapper.Map<List<ResultSubscribeDTO>>(subscribeList);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _subscribeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}