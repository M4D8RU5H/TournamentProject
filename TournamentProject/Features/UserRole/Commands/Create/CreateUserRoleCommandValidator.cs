using FluentValidation;

namespace TournamentProject.Features.UserRole.Commands.Create
{
    public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 40);
        }
    }
}
