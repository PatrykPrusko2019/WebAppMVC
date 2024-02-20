using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Application.FavouriteTeamsUser;
using WebAppMVC.Application.League.Commands.RemoveFavouriteTeam;
using WebAppMVC.Application.Team.Queries;
using WebAppMVC.Application.Team.Query;

namespace WebAppMVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly IMediator mediator;

        public TeamController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [Route("Team/ShowFavouriteMatches")]
        public async Task<IActionResult> ShowFavouriteMatches()
        {
            var favouriteTeams = await mediator.Send(new GetFavouriteTeamsByUserIdQuery());

            return View(favouriteTeams);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var result = mediator.Send(new RemoveFavouriteTeamCommand(id));
            return View();
        }

        [Authorize]
        [Route("Team/ShowAllFootballTeams")]
        public async Task<IActionResult> ShowAllFootballTeams()
        {
            var favouriteTeams = await mediator.Send(new GetShowAllFootballTeamsQuery());

            return View(favouriteTeams);
        }

        [Authorize]
        [Route("Team/ShowAllMatchQueues")]
        public async Task<IActionResult> ShowAllMatchQueues()
        {
            var favouriteTeams = await mediator.Send(new GetShowAllMatchQueuesQuery());

            return View(favouriteTeams);
        }
    }
}
