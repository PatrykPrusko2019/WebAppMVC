using AutoMapper;
using MediatR;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.League.Queries.GetLeagueById
{
    public class GetLeagueByIdQueryHandler : IRequestHandler<GetLeagueByIdQuery, IEnumerable<FootballTeamDto>>
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly IMapper mapper;

        public GetLeagueByIdQueryHandler(ILeagueRepository leagueRepository, IMapper mapper)
        {
            this.leagueRepository = leagueRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<FootballTeamDto>> Handle(GetLeagueByIdQuery request, CancellationToken cancellationToken)
        {
            var league = await leagueRepository.GetLeagueById(request.Id);

            var footballTeamDto = mapper.Map<IEnumerable<FootballTeamDto>>(league.FootballTeams);

            return footballTeamDto;
        }
    }
}
