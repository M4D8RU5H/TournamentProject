using FluentValidation;

namespace TournamentProject.Features.Tournament.Queries.GetSingle
{
    public class GetSingleTournamentQueryValidator : AbstractValidator<GetSingleTournamentQuery>
    {
        public GetSingleTournamentQueryValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
