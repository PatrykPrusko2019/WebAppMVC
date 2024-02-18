using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Application.Match;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.League.Queries.GetMatchResultsByTeamId
{
    public class GetMatchResultsByTeamIdHandler : IRequestHandler<GetMatchResultsByTeamIdQuery, IEnumerable<MatchDto>>
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly IMapper mapper;

        public GetMatchResultsByTeamIdHandler(ILeagueRepository leagueRepository, IMapper mapper)
        {
            this.leagueRepository = leagueRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> Handle(GetMatchResultsByTeamIdQuery request, CancellationToken cancellationToken)
        {
            var matchResults = await leagueRepository.GetMatchResultsByTeamIdQuery(request.Id);

            var matchResultsDto = mapper.Map<IEnumerable<MatchDto>>(matchResults);

            


            return matchResultsDto;
        }
    }
}
