using MediatR;
using WebAppMVC.Application.FootballTeam;

namespace WebAppMVC.Application.Team.Queries
{
    public class GetShowAllFootballTeamsQuery : IRequest<IEnumerable<FootballTeamDto>>
    {
    }
}
