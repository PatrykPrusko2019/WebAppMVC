using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.ApplicationUser;
using WebAppMVC.Application.FavouriteTeamsUser;
using WebAppMVC.Application.Match;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.League.Queries.AddNewTeamToFavouriteTeams
{
    public class AddNewTeamToFavouriteTeamsHandler : IRequestHandler<AddNewTeamToFavouriteTeamsQuery, FavouriteTeamsUserDto>
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public AddNewTeamToFavouriteTeamsHandler(ILeagueRepository leagueRepository, IMapper mapper, IUserContext userContext)
        {
            this.leagueRepository = leagueRepository;
            this.mapper = mapper;
            this.userContext = userContext;
        }

        public async Task<FavouriteTeamsUserDto> Handle(AddNewTeamToFavouriteTeamsQuery request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser().Id;

            var favouriteTeam = await leagueRepository.AddTeamToFavouriteTeamsByTeamId(request.Id, userId);

            if (string.IsNullOrEmpty(favouriteTeam.UserId)) return null;
            var teamResultDto = mapper.Map<FavouriteTeamsUserDto>(favouriteTeam);

            teamResultDto.UserId = userId;

            return teamResultDto;
        }
    }
}
