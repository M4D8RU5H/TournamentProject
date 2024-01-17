using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TournamentProject.Features.Team.Queries.GetSingle
{
    public class GetSingleTeamQueryHandler : IRequestHandler<GetSingleTeamQuery, GetSingleTeamQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetSingleTeamQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleTeamQueryResult> Handle(GetSingleTeamQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSingleTeamQueryValidator();

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return new GetSingleTeamQueryResult
            {
                Team =  await _context.Teams
                .Where(t => t.Id == query.Id)
                .Select(t => new GetSingleTeamQueryResult.TeamDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Ratio = t.Ratio,
                    TeamMembers = t.Team_Users.Select(x => new GetSingleTeamQueryResult.UserDto
                    {
                        Id = x.User.Id,
                        Name = x.User.Name,
                        Rank = x.User.Rank
                    }).ToList()
                }).FirstOrDefaultAsync()
            };
        }
    }
}
