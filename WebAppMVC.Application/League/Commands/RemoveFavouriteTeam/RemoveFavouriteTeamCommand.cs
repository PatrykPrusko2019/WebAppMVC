using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.League.Commands.RemoveFavouriteTeam
{
    public class RemoveFavouriteTeamCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFavouriteTeamCommand(int id)
        {
            Id = id;
        }
    }
}
