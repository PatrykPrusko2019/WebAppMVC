using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Domain.Interfaces;
using WebAppMVC.Infrastructure.Persistence;
using WebAppMVC.Infrastructure.Seeders;

namespace WebAppMVC.Infrastructure.Repository
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly WebAppMVCDbContext _dbContext;
        private string[] listsTeamsFirstLeagua = new string[16] { "FirstTeam", "SecondTeam", "ThirdTeam", "FourthTeam", "FifthTeam", "SixthTeam", "SeventhTeam", "EighthTeam",
                                                                    "NinthTeam", "TenthTeam", "EleventhTeam", "TwelfthTeam", "ThirteenthTeam", "FourteenthTeam", "FifteenthTeam", "SixteenthTeam" };

        public LeagueRepository(WebAppMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(League league)
        {
            string[] actualList = new string[16];

            var listsFirstTeamsLeagua = null != league.TeamNames ? league.TeamNames.Split(";") : null;
            if (listsFirstTeamsLeagua != null)
            {
                if (listsFirstTeamsLeagua.Length == 16)
                {
                    actualList = listsFirstTeamsLeagua;
                }
                else
                {
                    for (int i = 0; i < listsFirstTeamsLeagua.Count(); i++)
                    {
                        if (listsFirstTeamsLeagua.IsNullOrEmpty()) actualList[i] = listsTeamsFirstLeagua[i];
                        else actualList[i] = listsFirstTeamsLeagua[i];
                    }

                    for (int i = listsFirstTeamsLeagua.Count()-1; i < actualList.Count(); i++)
                    {
                        actualList[i] = listsTeamsFirstLeagua[i];
                    }
                }

                
            }
            else
            {
                actualList = listsTeamsFirstLeagua;
            }

            actualList = CheckDuplicateNameTeam(actualList);


            league.TeamNames = string.Join(";", actualList);

            //adds new footballTeams
            foreach (var teamName in actualList)
            {
                league.FootballTeams.Add(new FootballTeam() { Name = teamName, MeetingsWon = 0, Points = 0, LeagueName = league.Name });
            }

            _dbContext.Leagues.Add(league);
            await _dbContext.SaveChangesAsync();
        }

        private string[] CheckDuplicateNameTeam(string[] actualList)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < actualList.Length; i++) 
            {
                sb.Clear();
                string teamName = actualList[i];

                while (_dbContext.FootballTeams.Any(f => f.Name == actualList[i]))
                {
                    if (_dbContext.FootballTeams.Any(f => f.Name == teamName))
                    {
                        Random random = new Random();
                        sb.Append(teamName + random.Next(10_000));
                        actualList[i] = sb.ToString();
                    }
                }
                
            }
            return actualList;
        }

        public async Task<IEnumerable<League>> GetAll()
        => await _dbContext.Leagues.ToListAsync();

        public Task<League?> GetByName(string name)
        => _dbContext.Leagues.FirstOrDefaultAsync(l => l.Name.ToLower() == name.ToLower());

        public async Task<League> GetLeagueById(int id)
        => await _dbContext.Leagues
            .Include(f => f.FootballTeams)
            .FirstAsync(l => l.Id == id);

        public async Task<IEnumerable<Match>> GetMatchResultsByTeamId(int id)
        {
            var teamName = _dbContext.FootballTeams.FirstOrDefault(f => f.Id == id).Name;
            var matchResults = await _dbContext.Matches.Where(m => m.NameFirstTeam == teamName || m.NameSecondTeam == teamName).ToListAsync();

            if (matchResults == null || matchResults.Count == 0)
            { // created new match results
                FootballTeamSeeder footballTeamSeeder = new FootballTeamSeeder(_dbContext);
                var leagueName = _dbContext.FootballTeams.FirstOrDefault(f => f.Name == teamName).LeagueName;
                var results = footballTeamSeeder.GetQueues(leagueName);

                _dbContext.Queues.AddRange(results);
                await _dbContext.SaveChangesAsync();

                matchResults = await _dbContext.Matches.Where(m => m.NameFirstTeam == teamName || m.NameSecondTeam == teamName).ToListAsync();
            }

            return matchResults;
        }

        public async Task<FavouriteTeamsUser> AddTeamToFavouriteTeamsByTeamId(int id, string userId)
        {
            var team = _dbContext.FootballTeams.FirstOrDefault(f => f.Id == id);

            var favouriteTeam = new FavouriteTeamsUser()
            {
                FootballTeamId = team.Id,
                FootballTeamName = team.Name,
                MeetingsWon = team.MeetingsWon,
                Points = team.Points,
                LeagueName = team.LeagueName,
                LeagueId = team.LeagueId
            };

            favouriteTeam.UserId = userId;

            if (_dbContext.FavouriteTeamsUsers.Any(t => t.FootballTeamId == favouriteTeam.FootballTeamId)) return new FavouriteTeamsUser();
            _dbContext.FavouriteTeamsUsers.Add(favouriteTeam);
            _dbContext.SaveChanges();

            return favouriteTeam;
        }
    }
}
