using MediatR;

namespace WebAppMVC.Application.League.Queries.GetAllLeagues
{
    public class GetAllLeaguesQuery : IRequest<IEnumerable<LeagueDto>>
    {
    }
}
