using FluentValidation;

namespace TournamentProject.Features.Team.Commands.Update
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 30);
            RuleFor(x => x.Ratio).NotNull();
        }
    }
}
