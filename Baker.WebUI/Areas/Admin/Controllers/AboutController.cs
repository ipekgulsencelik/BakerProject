using Baker.WebUI.CQRS.Commands.AboutCommands;
using Baker.WebUI.CQRS.Handlers.AboutHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class AboutController : Controller
    {
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutController(GetAboutQueryHandler getAboutQueryHandler, CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, IWebHostEnvironment webHostEnvironment)
        {
            _getAboutQueryHandler = getAboutQueryHandler;
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var value = _getAboutQueryHandler.Handle();

            if (value.AboutID == null)
                ViewBag.flag = false;
            else
                ViewBag.flag = true;

            ViewBag.id = value.AboutID;
            ViewBag.mainTitle = value.AboutTitle;
            ViewBag.subTitle = value.AboutSubTitle;
            ViewBag.description1 = value.AboutDescription1;
            ViewBag.description2 = value.AboutDescription2;
            ViewBag.image1 = value.AboutImage1;
            ViewBag.image2 = value.AboutImage2;
            ViewBag.createdAt = value.CreatedAt;
            ViewBag.status = value.Status;

            return View();
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutCommand command, IFormFile image1, IFormFile image2)
        {
            string uniqueImageName1 = null;
            string uniqueImageName2 = null;

            if (image1 != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueImageName1 = Guid.NewGuid().ToString() + "_" + image1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueImageName1);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image1.CopyTo(fileStream);
                }
                command.AboutImage1 = uniqueImageName1;
            }

            if (image2 != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueImageName2 = Guid.NewGuid().ToString() + "_" + image2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueImageName2);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image2.CopyTo(fileStream);
                }
                command.AboutImage2 = uniqueImageName2;
            }

            command.CreatedAt = DateTime.Now;
            command.Status = true;

            _createAboutCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout()
        {
            var value = _getAboutQueryHandler.Handle();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutCommand command, IFormFile image1, IFormFile image2)
		{
			string uniqueImageName1 = null;
			string uniqueImageName2 = null;

			if (image1 != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				uniqueImageName1 = Guid.NewGuid().ToString() + "_" + image1.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueImageName1);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					image1.CopyTo(fileStream);
				}
				command.AboutImage1 = uniqueImageName1;
			}
			else
			{
				command.AboutImage1 = command.AboutImage1;
			}

			if (image2 != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				uniqueImageName2 = Guid.NewGuid().ToString() + "_" + image2.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueImageName2);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					image2.CopyTo(fileStream);
				}
				command.AboutImage2 = uniqueImageName2;
			}
			else
			{
				command.AboutImage2 = command.AboutImage2;
			}

			command.CreatedAt = DateTime.Now;
            command.Status = true;
            
            _updateAboutCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}