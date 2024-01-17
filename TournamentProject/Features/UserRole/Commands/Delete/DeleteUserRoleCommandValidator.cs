using FluentValidation;

namespace TournamentProject.Features.UserRole.Commands.Delete
{
    public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
    {
        public DeleteUserRoleCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
