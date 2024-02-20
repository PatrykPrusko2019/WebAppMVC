using AutoMapper;
using MediatR;
using WebAppMVC.Application.ApplicationUser;
using WebAppMVC.Application.FavouriteTeamsUser;
using WebAppMVC.Application.Team.Query;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.Team.Queries
{
    public class GetFavouriteTeamsByUserIdHandler : IRequestHandler<GetFavouriteTeamsByUserIdQuery, IEnumerable<FavouriteTeamsUserDto>>
    {
        private readonly ITeamRepository teamRepository;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public GetFavouriteTeamsByUserIdHandler(ITeamRepository teamRepository, IMapper mapper, IUserContext userContext)
        {
            this.teamRepository = teamRepository;
            this.mapper = mapper;
            this.userContext = userContext;
        }

        public async Task<IEnumerable<FavouriteTeamsUserDto>> Handle(GetFavouriteTeamsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser().Id;

            var favouriteTeams = await teamRepository.GetFavouriteTeamsByUserId(userId);

            var favouriteTeamsDtos = mapper.Map<IEnumerable<FavouriteTeamsUserDto>>(favouriteTeams);

            return favouriteTeamsDtos;
        }
    }
}
