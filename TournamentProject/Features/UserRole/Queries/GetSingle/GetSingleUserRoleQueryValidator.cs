using FluentValidation;

namespace TournamentProject.Features.UserRole.Queries.GetSingle
{
    public class GetSingleUserRoleQueryValidator : AbstractValidator<GetSingleUserRoleQuery>
    {
        public GetSingleUserRoleQueryValidator() 
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
