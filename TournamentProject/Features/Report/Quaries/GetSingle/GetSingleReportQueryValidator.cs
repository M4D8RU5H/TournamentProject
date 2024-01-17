using FluentValidation;

namespace TournamentProject.Features.Report.Quaries.GetSingle
{
    public class GetSingleReportQueryValidator : AbstractValidator<GetSingleReportQuery>
    {
        public GetSingleReportQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
