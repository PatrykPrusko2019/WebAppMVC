using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Application.Match;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.Team.Queries
{
    public class GetShowAllMatchQueuesHandler : IRequestHandler<GetShowAllMatchQueuesQuery, IEnumerable<MatchDto>>
    {
        private readonly ITeamRepository teamRepository;
        private readonly IMapper mapper;

        public GetShowAllMatchQueuesHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            this.teamRepository = teamRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MatchDto>> Handle(GetShowAllMatchQueuesQuery request, CancellationToken cancellationToken)
        {
            var matchQueues = await teamRepository.GetMatchQueues();

            var matchQueuesDtos = mapper.Map<IEnumerable<MatchDto>>(matchQueues);

            return matchQueuesDtos;
        }
    }
}
