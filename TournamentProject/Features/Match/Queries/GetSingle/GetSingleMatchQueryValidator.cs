using FluentValidation;

namespace TournamentProject.Features.Match.Queries.GetSingle
{
    public class GetSingleMatchQueryValidator : AbstractValidator<GetSingleMatchQuery>
    {
        public GetSingleMatchQueryValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
