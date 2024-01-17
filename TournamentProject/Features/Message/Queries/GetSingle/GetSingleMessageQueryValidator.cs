using FluentValidation;

namespace TournamentProject.Features.Message.Queries.GetSingle
{
    public class GetSingleMessageQueryValidator : AbstractValidator<GetSingleMessageQuery>
    {
        public GetSingleMessageQueryValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
