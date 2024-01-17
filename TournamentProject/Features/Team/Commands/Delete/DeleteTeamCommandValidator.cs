using FluentValidation;

namespace TournamentProject.Features.Team.Commands.Delete
{
    public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
    {
        public DeleteTeamCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
