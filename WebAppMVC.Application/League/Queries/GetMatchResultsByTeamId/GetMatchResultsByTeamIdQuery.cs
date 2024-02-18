using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Application.Match;

namespace WebAppMVC.Application.League.Queries.GetMatchResultsByTeamId
{
    public class GetMatchResultsByTeamIdQuery : IRequest<IEnumerable<MatchDto>>
    {
        public int Id { get; set; }

        public GetMatchResultsByTeamIdQuery(int id)
        {
            Id = id;
        }
    }
}
