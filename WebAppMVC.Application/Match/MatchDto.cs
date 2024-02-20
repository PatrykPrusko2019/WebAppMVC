using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.Match
{
    public class MatchDto
    {
        public int Id { get; set; }
        public string NameFirstTeam { get; set; }
        public string NameSecondTeam { get; set; }
        public int Result { get; set; }
        public string GoalScore { get; set; } // 4 : 3

        public int QueueId { get; set; }

        public string QueueName { get; set; }
        public int LeagueId { get; set; }

        public string Results { get; set; }
    }
}
