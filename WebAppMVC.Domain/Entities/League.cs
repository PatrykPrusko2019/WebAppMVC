using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Domain.Entities
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? TeamNames { get; set; } // separator -> ;
        public virtual List<FootballTeam> FootballTeams { get; set;} = new List<FootballTeam>();
    }
}
