using Baker.WebUI.CQRS.Commands.OfferCommands;
using Baker.WebUI.CQRS.Handlers.OfferHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class OfferController : Controller
    {
        private readonly GetOfferQueryHandler _getOfferQueryHandler;
        private readonly CreateOfferCommandHandler _createOfferCommandHandler;
        private readonly GetOfferByIdQueryHandler _getOfferByIdQueryHandler;
        private readonly UpdateOfferCommandHandler _updateOfferCommandHandler;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public OfferController(GetOfferQueryHandler getOfferQueryHandler, CreateOfferCommandHandler createOfferCommandHandler, GetOfferByIdQueryHandler getOfferByIdQueryHandler, UpdateOfferCommandHandler updateOfferCommandHandler, IWebHostEnvironment webHostEnvironment)
        {
            _getOfferQueryHandler = getOfferQueryHandler;
            _createOfferCommandHandler = createOfferCommandHandler;
            _getOfferByIdQueryHandler = getOfferByIdQueryHandler;
            _updateOfferCommandHandler = updateOfferCommandHandler;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var value = _getOfferQueryHandler.Handle();

            if (value.OfferID == null)
                ViewBag.flag = false;
            else
                ViewBag.flag = true;

            ViewBag.id = value.OfferID;
            ViewBag.mainTitle = value.OfferTitle;
            ViewBag.subTitle = value.OfferSubTitle;
            ViewBag.description = value.OfferDescription;
            ViewBag.image1 = value.OfferImage1;
            ViewBag.image2 = value.OfferImage2;
            ViewBag.createdAt = value.CreatedAt;
            ViewBag.status = value.Status;

            return View();
        }

        [HttpGet]
        public IActionResult CreateOffer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOffer(CreateOfferCommand command, IFormFile image1, IFormFile image2)
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
                command.OfferImage1 = uniqueImageName1;
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
                command.OfferImage2 = uniqueImageName2;
            }

            command.CreatedAt = DateTime.Now;
            command.Status = true;

            _createOfferCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateOffer()
        {
            var value = _getOfferQueryHandler.Handle();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateOffer(UpdateOfferCommand command, IFormFile image1, IFormFile image2)
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
                command.OfferImage1 = uniqueImageName1;
            }
            else
            {
                command.OfferImage1 = command.OfferImage1;
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
                command.OfferImage2 = uniqueImageName2;
            }
            else
            {
                command.OfferImage2 = command.OfferImage2;
            }

            command.CreatedAt = DateTime.Now;
            command.Status = true;

            _updateOfferCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}