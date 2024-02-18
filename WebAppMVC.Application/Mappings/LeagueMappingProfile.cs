using AutoMapper;
using WebAppMVC.Application.FootballTeam;
using WebAppMVC.Application.League;
using WebAppMVC.Application.Match;

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

            CreateMap<MatchDto, Domain.Entities.Match>();
            CreateMap<Domain.Entities.Match, MatchDto>();
        }
    }
}
