using FluentValidation;

namespace TournamentProject.Features.Tournament.Commands.Update
{
    public class UpdateTournamentCommandValidator : AbstractValidator<UpdateTournamentCommand>
    {
        public UpdateTournamentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 40);
            RuleFor(x => x.Description).Length(0, 750);
            RuleFor(x => x.RegistrationStarts).GreaterThan(DateTime.Now);
            RuleFor(x => x.RegistrationEnds).GreaterThan(DateTime.Now).GreaterThan(x => x.RegistrationStarts);
            RuleFor(x => x.TournamentDate).GreaterThan(DateTime.Now).GreaterThan(x => x.RegistrationStarts).GreaterThan(x => x.RegistrationEnds);
            RuleFor(x => x.MaxTeamAmount).GreaterThanOrEqualTo(4);
        }
    }
}
