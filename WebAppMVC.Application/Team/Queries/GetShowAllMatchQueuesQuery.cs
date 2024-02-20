using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Match;

namespace WebAppMVC.Application.Team.Queries
{
    public class GetShowAllMatchQueuesQuery : IRequest<IEnumerable<MatchDto>>
    {
    }
}
