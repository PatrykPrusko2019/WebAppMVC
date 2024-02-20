using Microsoft.EntityFrameworkCore;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Domain.Interfaces;
using WebAppMVC.Infrastructure.Persistence;

namespace WebAppMVC.Infrastructure.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly WebAppMVCDbContext _dbContext;

        public TeamRepository(WebAppMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FavouriteTeamsUser>> GetFavouriteTeamsByUserId(string userId)
            => await _dbContext.FavouriteTeamsUsers.Where(t => t.UserId == userId).ToListAsync();

        public async Task<IEnumerable<FootballTeam>> GetFootballTeams()
            => await _dbContext.FootballTeams.ToListAsync();

        public async Task<IEnumerable<Match>> GetMatchQueues()
            => await _dbContext.Matches.ToListAsync();
        
    }
}
