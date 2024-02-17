using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Application.League
{
    public class LeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? TeamNames { get; set; } // separator -> ;
        public virtual List<FootballTeamDto>? FootballTeams { get; set; }
    }
}
