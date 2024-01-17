using FluentValidation;

namespace TournamentProject.Features.Tournament.Commands.Delete
{
    public class DeleteTournamentCommandValidator : AbstractValidator<DeleteTournamentCommand>
    {
        public DeleteTournamentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
