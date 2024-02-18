using AutoMapper;
using MediatR;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.League.Commands.CreateLeague
{
    public class CreateLeagueCommandHandler : IRequestHandler<CreateLeagueCommand>
    {
        private readonly ILeagueRepository leagueRepository;
        private readonly IMapper mapper;

        public CreateLeagueCommandHandler(ILeagueRepository leagueRepository, IMapper mapper)
        {
            this.leagueRepository = leagueRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateLeagueCommand request, CancellationToken cancellationToken)
        {
            var league = mapper.Map<Domain.Entities.League>(request);
            await leagueRepository.Create(league);

            return Unit.Value;
        }
    }
}
