using FluentValidation;

namespace TournamentProject.Features.Team.Queries.GetSingle
{
    public class GetSingleTeamQueryValidator : AbstractValidator<GetSingleTeamQuery>
    {
        public GetSingleTeamQueryValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
