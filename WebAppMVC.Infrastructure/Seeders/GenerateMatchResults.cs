
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Infrastructure.Persistence;

namespace WebAppMVC.Infrastructure.Seeders
{
    interface IGenerateMatchResults
    {
        public IEnumerable<Queue> GenerateMatchResultGetMatchResults(string leagueName);
    }
    public class GenerateMatchResults : IGenerateMatchResults
    {
        private readonly WebAppMVCDbContext _dbContext;
        private string[] ListBelgianFirstLeagueTeams = new string[16] { "Genk", "Royale Union SG", "Antwerp", "Club Brugge", "Gent", "St. Liege", "Westerlo", "Cercle Brugge", "Charleroi", "Leuven", "Anderlecht", "St. Truiden", "KV Mechelen", "Kortrijk", "Eupen", "Oostende" };
        private string[] listBelgianSecondLeaguaTeams = new string[6] { "Zulte-Waregem", "Seraing", "KFCO Beerschot-Wilrijk", "Deinze", "Lommel", "Patro Eisden", };
        private string[] listsQueues = new string[15] { "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth", "Eleventh", "Twelfth", "Thirteenth", "Fourteenth", "Fifteenth" };

        public GenerateMatchResults(WebAppMVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

         IEnumerable<Queue> IGenerateMatchResults.GenerateMatchResultGetMatchResults(string leagueName)
        {
            var footballTeams = _dbContext.FootballTeams.Where(t => t.LeagueName == leagueName).ToList(); 

            string[] firstLEaqueTeams = new string[16];

            if (leagueName.Equals("Belgian"))
            {
                var results = ListBelgianFirstLeagueTeams.ToArray();
                Array.Copy(results, firstLEaqueTeams, results.Length);
            }
            else
            {
                for (int i = 0; i < firstLEaqueTeams.Length; i++)
                {
                    firstLEaqueTeams[i] = footballTeams[i].Name;
                }
            }

            var matches = new List<Domain.Entities.Match>();
            var queries = new List<Queue>();

            for (int i = 0; i < 16; i++)
            {
                if (i == 15) break;
                queries.Add(new Queue() { Description = listsQueues[i], Matches = new List<Domain.Entities.Match>() });
            }

            int rounds = firstLEaqueTeams.Length - 1;

            
            for (int round = 1; round <= rounds; round++)
            {
                // Console.WriteLine($"Queue {round}:");

                for (int i = 0; i < firstLEaqueTeams.Length / 2; i++)
                {
                    int team1Index = i;
                    int team2Index = firstLEaqueTeams.Length - 1 - i;

                    int team1Score = GenerateRandomScore();
                    int team2Score = GenerateRandomScore();

                    // Console.WriteLine($"{listsTeamsFirstLeagua[team1Index]} vs {listsTeamsFirstLeagua[team2Index]}  results: {team1Score} : {team2Score}");

                    var newMatch = CreateMatch(firstLEaqueTeams[team1Index], firstLEaqueTeams[team2Index], team1Score, team2Score);
                   
                    newMatch.QueueName = queries[round - 1].Description;
                    newMatch.LeagueId = footballTeams[round - 1].LeagueId;
                    queries[round - 1].Matches.Add(newMatch);

                    string searchedTeam = "";
                    int points = 0;
                    switch(newMatch.Result)
                    {
                        case 1:
                            searchedTeam = newMatch.NameFirstTeam;
                            points = 15;
                            break;
                        case 2:
                            searchedTeam = newMatch.NameSecondTeam;
                            points = 30;
                            break;
                        default:
                            searchedTeam = newMatch.NameSecondTeam;
                            points = 3;
                            break;

                    }

                    var footballTeam = footballTeams.FirstOrDefault(f => f.Name == searchedTeam);
                    if (footballTeam != null)
                    {
                        footballTeam.MeetingsWon++;
                        footballTeam.Points += points;
                        _dbContext.FootballTeams.Update(footballTeam);
                    }

                    _dbContext.SaveChanges();
                }

                RotateTeams(firstLEaqueTeams); 
            }

            return queries;
        }

        private Domain.Entities.Match CreateMatch(string nameFirstName, string nameSecondName, int team1Score, int team2Score)
        {
            Domain.Entities.Match match = new Domain.Entities.Match() { NameFirstTeam = nameFirstName, NameSecondTeam = nameSecondName };
            if (team1Score > team2Score) match.Result = 1; //first team win
            else if (team1Score < team2Score) match.Result = 2; // second team win
            else match.Result = 0; // draw in match

            match.GoalScore = $"{team1Score} : {team2Score}";
            return match;
        }

        private void RotateTeams(string[] teams)
        {
            // Move the teams one position to the left (except for the first team)
            string firstTeam = teams[0];

            for (int i = 1; i < teams.Length; i++)
            {
                teams[i - 1] = teams[i];
            }

            teams[teams.Length - 1] = firstTeam;
        }

        private int GenerateRandomScore()
        {
            Random random = new Random();
            return random.Next(0, 6); // draw in match for simplicity, we assume that the result can be from 0 to 5.
        }
    }
}
