using Baker.WebUI.CQRS.Commands.ServiceCommands;
using Baker.WebUI.CQRS.Handlers.OfferHandlers;
using Baker.WebUI.CQRS.Handlers.ServiceHandlers;
using Baker.WebUI.CQRS.Queries.ServiceQueries;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class ServiceController : Controller
    {
        private readonly GetServiceQueryHandler _getServiceQueryHandler;
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;
        private readonly GetServiceByIdQueryHandler _getServiceByIdQueryHandler;
        private readonly UpdateServiceCommandHandler _updateServiceCommandHandler;
        private readonly RemoveServiceCommandHandler _removeServiceCommandHandler;
        private readonly GetOfferQueryHandler _getOfferQueryHandler;

        public ServiceController(GetServiceQueryHandler getServiceQueryHandler, CreateServiceCommandHandler createServiceCommandHandler, GetServiceByIdQueryHandler getServiceByIdQueryHandler, UpdateServiceCommandHandler updateServiceCommandHandler, RemoveServiceCommandHandler removeServiceCommandHandler, GetOfferQueryHandler getOfferQueryHandler)
        {
            _getServiceQueryHandler = getServiceQueryHandler;
            _createServiceCommandHandler = createServiceCommandHandler;
            _getServiceByIdQueryHandler = getServiceByIdQueryHandler;
            _updateServiceCommandHandler = updateServiceCommandHandler;
            _removeServiceCommandHandler = removeServiceCommandHandler;
            _getOfferQueryHandler = getOfferQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getServiceQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceCommand command)
        {
            var value = _getOfferQueryHandler.Handle();
            command.OfferID = value.OfferID;
            command.CreatedAt = DateTime.Now;

            _createServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(string id)
        {
            var values = _getServiceByIdQueryHandler.Handle(new GetServiceByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateService(UpdateServiceCommand command)
        {
            command.OfferID = command.OfferID;
            command.CreatedAt = DateTime.Now;

            _updateServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(string id)
        {
            _removeServiceCommandHandler.Handle(new RemoveServiceCommand(id));
            return RedirectToAction("Index");
        }
    }
}