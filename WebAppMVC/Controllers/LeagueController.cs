using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Application.League;
using WebAppMVC.Application.League.Commands.CreateLeague;
using WebAppMVC.Application.League.Queries.GetAllLeagues;
using WebAppMVC.Application.League.Queries.GetLeagueById;
using WebAppMVC.Application.League.Queries.GetMatchResultsByTeamId;

namespace WebAppMVC.Controllers
{
    public class LeagueController : Controller
    {
        private readonly IMediator mediator;

        public LeagueController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var leagues = await mediator.Send(new GetAllLeaguesQuery());
            return View(leagues);
        }

        public IActionResult Create()
        {
            return View();
        }


        [Route("League/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var leagueDto = await mediator.Send(new GetLeagueByIdQuery(id));
            return View(leagueDto);
        }


        [Route("League/{id}/ShowMatches")]
        public async Task<IActionResult> ShowMatches(int id)
        {
            var leagueDto = await mediator.Send(new GetMatchResultsByTeamIdQuery(id));
            
            return View(leagueDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateLeagueCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await mediator.Send(command);
            return RedirectToAction(nameof(Index)); 
        }

    }
}
