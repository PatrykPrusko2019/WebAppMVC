using MediatR;
using WebAppMVC.Application.FavouriteTeamsUser;

namespace WebAppMVC.Application.League.Queries.AddNewTeamToFavouriteTeams
{
    public class AddNewTeamToFavouriteTeamsQuery : IRequest<FavouriteTeamsUserDto>
    {
        public int Id { get; set; }

        public AddNewTeamToFavouriteTeamsQuery(int id)
        {
            Id = id;
        }
    }
}
