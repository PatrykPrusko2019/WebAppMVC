using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Domain.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<FavouriteTeamsUser>> GetFavouriteTeamsByUserId(string userId);
    }
}
