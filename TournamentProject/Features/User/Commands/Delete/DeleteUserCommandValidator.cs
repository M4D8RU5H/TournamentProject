using FluentValidation;

namespace TournamentProject.Features.User.Commands.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
