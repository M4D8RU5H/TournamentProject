using FluentValidation;

namespace TournamentProject.Features.UserRole.Commands.Update
{
    public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
    {
        public UpdateUserRoleCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 40);
        }
    }
}
