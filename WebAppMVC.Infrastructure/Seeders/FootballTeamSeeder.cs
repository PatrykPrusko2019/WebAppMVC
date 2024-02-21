using Microsoft.EntityFrameworkCore;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Infrastructure.Persistence;

namespace WebAppMVC.Infrastructure.Seeders
{
    public class FootballTeamSeeder
    {
        private readonly WebAppMVCDbContext _dbContext;
        private string[] listsTeamsFirstLeagua = new string[16] { "Genk", "Royale Union SG", "Antwerp", "Club Brugge", "Gent", "St. Liege", "Westerlo", "Cercle Brugge", "Charleroi", "Leuven", "Anderlecht", "St. Truiden", "KV Mechelen", "Kortrijk", "Eupen", "Oostende" };
        public FootballTeamSeeder(WebAppMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!await _dbContext.Database.CanConnectAsync()) 
            {
                
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
                
                if (!_dbContext.Leagues.Any())
                {
                    var league = new League() {Name = "Belgian", FootballTeams = new List<FootballTeam>(), TeamNames = String.Join(";", listsTeamsFirstLeagua) };
                    
                    foreach (var teamName in listsTeamsFirstLeagua)
                    {
                        league.FootballTeams.Add(new FootballTeam() { Name = teamName, MeetingsWon = 0, Points = 0, LeagueName = league.Name });
                    }

                    _dbContext.Leagues.Add(league);
                    await _dbContext.SaveChangesAsync();
                }

                if (!_dbContext.Queues.Any())
                {
                    var queues = GetQueues("Belgian");
                    _dbContext.Queues.AddRange(queues);
                    await _dbContext.SaveChangesAsync();
                }

            }

        }

        public IEnumerable<Queue> GetQueues(string leagueName)
        {
            IGenerateMatchResults generateMatchResults = new GenerateMatchResults(_dbContext);

            return generateMatchResults.GenerateMatchResultGetMatchResults(leagueName);

        }

    }
}
