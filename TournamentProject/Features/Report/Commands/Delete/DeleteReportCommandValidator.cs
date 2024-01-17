using FluentValidation;

namespace TournamentProject.Features.Report.Commands.Delete
{
    public class DeleteReportCommandValidator : AbstractValidator<DeleteReportCommand>
    {
        public DeleteReportCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
