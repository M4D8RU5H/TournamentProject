using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Team.Queries.GetSingle;
using TournamentProject.Features.Team.Queries.GetUserTeams;
using TournamentProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TournamentProject.Features.Team.Queries.Nowy_folder
{
    public class GetUserTeamsQueryHandler : IRequestHandler<GetUserTeamsQuery, GetUserTeamsQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetUserTeamsQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetUserTeamsQueryResult> Handle(GetUserTeamsQuery request, CancellationToken cancellationToken)
        {
            return new GetUserTeamsQueryResult
            {
                Teams = await _context.Teams
                    .Where(t => t.Team_Users.Any(tu => tu.UserId == request.Id))
                    .Select(t => new GetUserTeamsQueryResult.TeamDto
                    {
                        Id = t.Id,
                        TeamName = t.Name
                    })
                    .ToListAsync()
            };
        }
    }
}
