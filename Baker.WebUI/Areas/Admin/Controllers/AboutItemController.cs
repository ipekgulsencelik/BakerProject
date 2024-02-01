using Baker.WebUI.CQRS.Commands.AboutItemCommands;
using Baker.WebUI.CQRS.Handlers.AboutHandlers;
using Baker.WebUI.CQRS.Handlers.AboutItemHandlers;
using Baker.WebUI.CQRS.Queries.AboutItemQueries;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class AboutItemController : Controller
    {
        private readonly GetAboutItemQueryHandler _getItemQueryHandler;
        private readonly CreateAboutItemCommandHandler _createItemCommandHandler;
        private readonly GetAboutItemByIdQueryHandler _getItemByIdQueryHandler;
        private readonly UpdateAboutItemCommandHandler _updateItemCommandHandler;
        private readonly RemoveAboutItemCommandHandler _removeItemCommandHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;

        public AboutItemController(GetAboutItemQueryHandler getItemQueryHandler, CreateAboutItemCommandHandler createItemCommandHandler, GetAboutItemByIdQueryHandler getItemByIdQueryHandler, UpdateAboutItemCommandHandler updateItemCommandHandler, RemoveAboutItemCommandHandler removeItemCommandHandler, GetAboutQueryHandler getAboutQueryHandler)
        {
            _getItemQueryHandler = getItemQueryHandler;
            _createItemCommandHandler = createItemCommandHandler;
            _getItemByIdQueryHandler = getItemByIdQueryHandler;
            _updateItemCommandHandler = updateItemCommandHandler;
            _removeItemCommandHandler = removeItemCommandHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getItemQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAboutItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAboutItem(CreateAboutItemCommand command)
        {
            var value = _getAboutQueryHandler.Handle();
            command.AboutID = value.AboutID;
            command.CreatedAt = DateTime.Now;

            _createItemCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAboutItem(string id)
        {
            var values = _getItemByIdQueryHandler.Handle(new GetAboutItemByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAboutItem(UpdateAboutItemCommand command)
        {
            command.AboutID = command.AboutID;
            command.CreatedAt = DateTime.Now;

            _updateItemCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAboutItem(string id)
        {
            _removeItemCommandHandler.Handle(new RemoveAboutItemCommand(id));
            return RedirectToAction("Index");
        }
    }
}