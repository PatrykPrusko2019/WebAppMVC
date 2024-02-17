using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.FootballTeam
{
    public class FootballTeamDto
    {
        public string Name { get; set; }
        public int MeetingsWon { get; set; }
        public int Points { get; set; }
        public string LeagueName { get; set; }

        public int LeagueId { get; set; }
    }
}
