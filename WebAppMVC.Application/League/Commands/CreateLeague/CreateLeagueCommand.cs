using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Application.League.Commands.CreateLeague
{
    public class CreateLeagueCommand : LeagueDto, IRequest { }
}
