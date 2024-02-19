using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.FavouriteTeamsUser;

namespace WebAppMVC.Application.Team.Query
{
    public class GetFavouriteTeamsByUserIdQuery : IRequest<IEnumerable<FavouriteTeamsUserDto>>
    {
    }
}
