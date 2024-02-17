using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FootballTeam;

namespace WebAppMVC.Application.League.Queries.GetLeagueById
{
    public class GetLeagueByIdQuery : IRequest<IEnumerable<FootballTeamDto>>
    {
        public int Id { get; set; }

        public GetLeagueByIdQuery(int id)
        {
            Id = id;
        }
    }
}
