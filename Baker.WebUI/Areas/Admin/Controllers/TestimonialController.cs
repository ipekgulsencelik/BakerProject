using Baker.WebUI.Mediator.Commands.TestimonialCommands;
using Baker.WebUI.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TestimonialController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command, IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                command.TestimonialImageURL = uniqueFileName;
            }

            command.CreatedAt = DateTime.Now;
           
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialDetails(string id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return View(values);
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeTestimonialStatus(string id)
        {
            await _mediator.Send(new ChangeTestimonialStatusCommand(id));
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command, IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                command.TestimonialImageURL = uniqueFileName;
            }
            else
            {
                command.TestimonialImageURL = command.TestimonialImageURL;
            }

            command.CreatedAt = DateTime.Now;

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}