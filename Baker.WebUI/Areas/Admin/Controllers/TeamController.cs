using Baker.WebUI.Mediator.Commands.TeamCommands;
using Baker.WebUI.Mediator.Queries.TeamQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Baker.WebUI.Areas.Admin.Controllers
{
    public class TeamController : Controller
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetTeamQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTeam(string id)
        {
            await _mediator.Send(new RemoveTeamCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(string id)
        {
            var values = await _mediator.Send(new GetTeamByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}