using FluentValidation;

namespace TournamentProject.Features.User.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Login).NotNull().NotEmpty().Length(1, 40).EmailAddress();
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 40);
            RuleFor(x => x.Password).NotNull().NotEmpty().Length(1, 40);
            RuleFor(x => x.RoleId).GreaterThan(0);
        }
    }
}
