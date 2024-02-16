using WebAppMVC.Application.League;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Application.Services
{
    public interface ILeagueService
    {
        Task Create(LeagueDto league);
    }
}