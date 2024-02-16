
using System.Text.Json;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Infrastructure.Persistence;

namespace WebAppMVC.Infrastructure.Seeders
{
    public class FootballTeamSeeder
    {
        private readonly WebAppMVCDbContext _dbContext;
        private string[] listsTeamsFirstLeagua = new string[16] { "Genk", "Royale Union SG", "Antwerp", "Club Brugge", "Gent", "St. Liege", "Westerlo", "Cercle Brugge", "Charleroi", "Leuven", "Anderlecht", "St. Truiden", "KV Mechelen", "Kortrijk", "Eupen", "Oostende" };
        private string[] listsTeamsSecondLeagua = new string[6] { "Zulte-Waregem", "Seraing", "KFCO Beerschot-Wilrijk", "Deinze", "Lommel", "Patro Eisden", };
        private string[] listsQueues = new string[15] { "First", "Second", "Third", "Fourth", "Fifth", "Sixth","Seventh" , "Eighth", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth", "Fourteenth", "Fifteenth" }; 
        public FootballTeamSeeder(WebAppMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync()) 
            {
                
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
                    var queues = GetQueues();
                    _dbContext.Queues.AddRange(queues);
                    await _dbContext.SaveChangesAsync();
                }

            }

        }

        private IEnumerable<Queue> GetQueues()
        {
            var footballTeams = _dbContext.FootballTeams.Where(t => t.LeagueName == "Belgian").ToList(); // Belgian League

            var matches = new List<Match>();
            var queries = new List<Queue>();

            int numberOfTeams = 16;

            // Initialisation of the teams
            int[] teams = new int[numberOfTeams];
            for (int i = 0; i < numberOfTeams; i++)
            {
                teams[i] = i + 1;

                if (i == 15) break;
                queries.Add(new Queue() { Description = listsQueues[i], Matches = new List<Match>() });

            }

            // Start of the tournament
            for (int round = 1; round <= numberOfTeams - 1; round++)
            {

                // Transfer of teams
                int temp = teams[numberOfTeams - 1];
                Array.Copy(teams, 0, teams, 1, numberOfTeams - 1);
                teams[0] = temp;

                // Generation of match pairs
                for (int i = 0; i < numberOfTeams / 2; i++)
                {
                    var firstMatch = teams[i];
                    var secondMatch = teams[i + numberOfTeams / 2];
                    Random random = new Random();
                    var match = new Match() { NameFirstTeam = footballTeams[firstMatch - 1].Name, NameSecondTeam = footballTeams[secondMatch - 1].Name, Result = random.Next(2)+1 };
                    match.GoalScore = match.Result == 1 ? "1 : 0" : "0 : 1";
                    queries[round - 1].Matches.Add(match);

                    var footballTeam = footballTeams.FirstOrDefault(f => f.Name == (match.Result == 1 ? match.NameFirstTeam : match.NameSecondTeam));
                    if (footballTeam != null)
                    {
                        footballTeam.MeetingsWon++;
                        footballTeam.Points += 10;
                        _dbContext.FootballTeams.Update(footballTeam);
                    }
                    
                    _dbContext.SaveChanges();
                }

            }
            return queries;
        }

    }
}
