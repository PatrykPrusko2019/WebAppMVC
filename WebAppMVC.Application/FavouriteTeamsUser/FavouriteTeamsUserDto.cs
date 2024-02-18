using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FootballTeam;

namespace WebAppMVC.Application.FavouriteTeamsUser
{
    public class FavouriteTeamsUserDto
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
