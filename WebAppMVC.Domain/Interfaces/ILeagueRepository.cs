using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Domain.Interfaces
{
    public interface ILeagueRepository
    {
        Task Create(League league);
        Task<League?> GetByName(string name);
        Task<IEnumerable<League>> GetAll();
        Task<League> GetLeagueById(int id);
        Task<IEnumerable<Match>> GetMatchResultsByTeamId(int id);
        Task<FavouriteTeamsUser?> AddTeamToFavouriteTeamsByTeamId(int id, string userId);
        Task Delete(int id);
    }
}
