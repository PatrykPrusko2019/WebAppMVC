using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Domain.Entities
{
    public class FavouriteTeamsUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int FootballTeamId { get; set; }
        public string FootballTeamName { get; set; }
        public int MeetingsWon { get; set; }
        public int Points { get; set; }
        public string LeagueName { get; set; }
        public int LeagueId { get; set; }
    }
}
