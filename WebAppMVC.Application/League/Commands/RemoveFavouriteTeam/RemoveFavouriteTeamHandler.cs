
using AutoMapper;
using MediatR;
using WebAppMVC.Application.ApplicationUser;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.League.Commands.RemoveFavouriteTeam
{
    public class RemoveFavouriteTeamHandler : IRequestHandler<RemoveFavouriteTeamCommand>
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly IMapper mapper;

        public RemoveFavouriteTeamHandler(ILeagueRepository leagueRepository, IMapper mapper)
        {
            this.leagueRepository = leagueRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(RemoveFavouriteTeamCommand request, CancellationToken cancellationToken)
        {
            await leagueRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
