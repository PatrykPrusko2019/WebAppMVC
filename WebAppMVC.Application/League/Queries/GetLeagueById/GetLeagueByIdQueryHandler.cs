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

            var results = footballTeamDto.OrderByDescending(f => f.Points);

            var listResults = results.ToList();

            for (var i = 0; i < listResults.Count(); i++)
            {
                var temp = listResults.ElementAt(i).Points;

                if (temp == listResults.ElementAt(i + 1).Points)
                {
                    if (listResults.ElementAt(i).MeetingsWon < listResults.ElementAt(i+1).MeetingsWon)
                    {
                        var temp2 = listResults[i];
                        listResults[i] = listResults[i+1];
                        listResults[i+1] = temp2;
                    }
                }
                if (i + 1 == results.Count()-1) break;
            }

            return results.ToArray();
        }
    }
}
