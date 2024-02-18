using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FavouriteTeamsUser;
using WebAppMVC.Application.Match;

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
