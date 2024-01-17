using FluentValidation;

namespace TournamentProject.Features.User.Queries.GetSingle
{
    public class GetSingleUserQueryValidator : AbstractValidator<GetSingleUserQuery>
    {
        public GetSingleUserQueryValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
