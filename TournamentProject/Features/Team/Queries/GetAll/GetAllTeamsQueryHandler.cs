using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Team.Queries.GetSingle;
using TournamentProject.Models;

namespace TournamentProject.Features.Team.Queries.GetAll
{
    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, GetAllTeamsQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllTeamsQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllTeamsQueryResult> Handle(GetAllTeamsQuery query, CancellationToken cancellationToken)
        {
            return new GetAllTeamsQueryResult
            {
                Teams = await _context.Teams
                .Select(t => new GetAllTeamsQueryResult.TeamDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Ratio = t.Ratio,
                    TeamMembers = t.Team_Users.Select(x => new GetAllTeamsQueryResult.UserDto
                    {
                        Id = x.User.Id,
                        Name = x.User.Name,
                        Rank = x.User.Rank
                    }).ToList()
                }).ToListAsync()
            };
        }
    }
}
