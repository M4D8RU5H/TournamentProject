using FluentValidation;

namespace TournamentProject.Features.Team.Commands.Create
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 30);
            RuleFor(x => x.Ratio).NotNull();
        }
    }
}
