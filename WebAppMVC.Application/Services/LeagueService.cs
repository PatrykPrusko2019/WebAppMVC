using AutoMapper;
using WebAppMVC.Application.League;
using WebAppMVC.Domain.Entities;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly IMapper mapper;

        public LeagueService(ILeagueRepository leagueRepository, IMapper mapper)
        {
            this.leagueRepository = leagueRepository;
            this.mapper = mapper;
        }

        public async Task Create(LeagueDto leagueDto)
        {
            var league = mapper.Map<Domain.Entities.League>(leagueDto);
            await leagueRepository.Create(league);
        }
    }
}
