using Microsoft.IdentityModel.Tokens;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Domain.Interfaces;
using WebAppMVC.Infrastructure.Persistence;

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

            league.TeamNames = string.Join(";", actualList);

            //adds new footballTeams
            foreach (var teamName in actualList)
            {
                league.FootballTeams.Add(new FootballTeam() { Name = teamName, MeetingsWon = 0, Points = 0, LeagueName = league.Name });
            }

            _dbContext.Leagues.Add(league);
            await _dbContext.SaveChangesAsync();
        }
    }
}
