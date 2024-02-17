using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.League.Queries.GetAllLeagues
{
    public class GetAllLeaguesQueryHandler : IRequestHandler<GetAllLeaguesQuery, IEnumerable<LeagueDto>>
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly IMapper mapper;

        public GetAllLeaguesQueryHandler(ILeagueRepository leagueRepository, IMapper mapper)
        {
            this.leagueRepository = leagueRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LeagueDto>> Handle(GetAllLeaguesQuery request, CancellationToken cancellationToken)
        {
            var leagues = await leagueRepository.GetAll();
            var leaguesDto = mapper.Map<IEnumerable<LeagueDto>>(leagues);

            return leaguesDto;
        }
    }
}
