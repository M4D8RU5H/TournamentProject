using FluentValidation;

namespace TournamentProject.Features.Report.Commands.Create
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty().Length(1, 750);
        }
    }
}
