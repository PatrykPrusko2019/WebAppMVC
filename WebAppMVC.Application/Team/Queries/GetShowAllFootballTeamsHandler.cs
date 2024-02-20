using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.Team.Queries
{
    public class GetShowAllFootballTeamsHandler : IRequestHandler<GetShowAllFootballTeamsQuery, IEnumerable<FootballTeamDto>>
    {
        private readonly ITeamRepository teamRepository;
        private readonly IMapper mapper;

        public GetShowAllFootballTeamsHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            this.teamRepository = teamRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<FootballTeamDto>> Handle(GetShowAllFootballTeamsQuery request, CancellationToken cancellationToken)
        {
            var footballTeams = await teamRepository.GetFootballTeams();

            var footballTeamsDtos = mapper.Map<IEnumerable<FootballTeamDto>>(footballTeams);

            return footballTeamsDtos;
        }
    }
}
