using AutoMapper;
using WebAppMVC.Application.League;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Application.Mappings
{
    public class LeagueMappingProfile : Profile
    {
        public LeagueMappingProfile()
        {
            CreateMap<LeagueDto, Domain.Entities.League>();
        }
    }
}
