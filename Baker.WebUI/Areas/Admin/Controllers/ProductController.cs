using Baker.WebUI.Mediator.Commands.ProductCommands;
using Baker.WebUI.Mediator.Queries.CategoryQueries;
using Baker.WebUI.Mediator.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetProductQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var values = await _mediator.Send(new GetCategoryQuery());
            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryName
                                               }).ToList();
            ViewBag.category = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command, IFormFile image)
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
                command.ProductImage = uniqueFileName;
            }

            command.CreatedAt = DateTime.Now;

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            return View(product);
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _mediator.Send(new GetCategoryQuery());
            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryName
                                               }).ToList();
            ViewBag.category = categories;

            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command, IFormFile image)
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
                command.ProductImage = uniqueFileName;
            }
            else
            {
                command.ProductImage = command.ProductImage;
            }

            command.CreatedAt = DateTime.Now;

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}