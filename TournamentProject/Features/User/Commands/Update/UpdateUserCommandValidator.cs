using FluentValidation;

namespace TournamentProject.Features.User.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Login).NotNull().NotEmpty().Length(1, 40).EmailAddress();
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 40);
            RuleFor(x => x.Password).NotNull().NotEmpty().Length(1, 40);
            RuleFor(x => x.RoleId).GreaterThan(0);
            RuleFor(x => x.BannedUntill).GreaterThan(DateTime.Now);
        }
    }
}
