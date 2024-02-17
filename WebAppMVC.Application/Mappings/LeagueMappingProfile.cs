using AutoMapper;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Application.League;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Application.Mappings
{
    public class LeagueMappingProfile : Profile
    {
        public LeagueMappingProfile()
        {
            CreateMap<LeagueDto, Domain.Entities.League>();

            CreateMap<Domain.Entities.League, LeagueDto>();

            CreateMap<FootballTeamDto, Domain.Entities.FootballTeam>();
            CreateMap<Domain.Entities.FootballTeam, FootballTeamDto>();
        }
    }
}
