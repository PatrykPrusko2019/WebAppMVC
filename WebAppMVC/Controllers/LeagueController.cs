using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Application.League;
using WebAppMVC.Application.Services;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueService leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeagueDto league)
        {
            if (!ModelState.IsValid)
            {
                return View(league);
            }

            await leagueService.Create(league);
            return RedirectToAction(nameof(Create)); // todo refactor
        }
    }
}
