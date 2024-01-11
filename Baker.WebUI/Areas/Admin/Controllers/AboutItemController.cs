using Baker.WebUI.CQRS.Commands.AboutItemCommands;
using Baker.WebUI.CQRS.Handlers.AboutItemHandlers;
using Baker.WebUI.CQRS.Queries.AboutItemQueries;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    public class AboutItemController : Controller
    {
        private readonly GetAboutItemQueryHandler _getItemQueryHandler;
        private readonly CreateAboutItemCommandHandler _createItemCommandHandler;
        private readonly GetAboutItemByIdQueryHandler _getItemByIdQueryHandler;
        private readonly UpdateAboutItemCommandHandler _updateItemCommandHandler;
        private readonly RemoveAboutItemCommandHandler _removeItemCommandHandler;

        public AboutItemController(GetAboutItemQueryHandler getItemQueryHandler, CreateAboutItemCommandHandler createItemCommandHandler, GetAboutItemByIdQueryHandler getItemByIdQueryHandler, UpdateAboutItemCommandHandler updateItemCommandHandler, RemoveAboutItemCommandHandler removeItemCommandHandler)
        {
            _getItemQueryHandler = getItemQueryHandler;
            _createItemCommandHandler = createItemCommandHandler;
            _getItemByIdQueryHandler = getItemByIdQueryHandler;
            _updateItemCommandHandler = updateItemCommandHandler;
            _removeItemCommandHandler = removeItemCommandHandler;
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