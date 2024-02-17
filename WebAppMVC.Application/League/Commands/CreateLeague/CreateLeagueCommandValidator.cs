using FluentValidation;
using WebAppMVC.Domain.Interfaces;

namespace WebAppMVC.Application.League.Commands.CreateLeague
{
    public class CreateLeagueCommandValidator : AbstractValidator<CreateLeagueCommand>
    {
        public CreateLeagueCommandValidator(ILeagueRepository repository)
        {
            RuleFor(l => l.Name)
                .NotEmpty().WithMessage("The Name field must not be empty !")
                .MinimumLength(6).WithMessage("Enter a minimum of 6 characters !")
                .MaximumLength(30).WithMessage("Enter max 30 characters !")
                .Custom((value, context) =>
                {
                    var existingLeague = repository.GetByName(value).Result;
                    if (existingLeague != null)
                    {
                        context.AddFailure($"{value} is not unigue name for League !");
                    }
                });
        }
    }
}
