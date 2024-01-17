using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Match.Queries.GetAll
{
    public class GetAllMatchesQueryHandler : IRequestHandler<GetAllMatchesQuery, GetAllMatchesQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllMatchesQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllMatchesQueryResult> Handle(GetAllMatchesQuery query, CancellationToken cancellationToken)
        {
            var matches = await _context.Matches
                .Where(x => x.TournamentId == query.Id)
                .Select(x => new GetAllMatchesQueryResult.MatchDto
                {
                    Id = x.Id,
                    FirstTeamId = x.FirstTeamId,
                    SecondTeamId = x.SecondTeamId,
                    WinnerId = (int)x.WinnerId,
                    Score = x.Score,
                    TournamentId = x.TournamentId,
                    Phase = x.Phase,
                    FirstTeamName = _context.Teams.FirstOrDefault(t => t.Id == x.FirstTeamId).Name,
                    SecondTeamName = _context.Teams.FirstOrDefault(t => t.Id == x.SecondTeamId).Name
                })
                .ToListAsync();

            return new GetAllMatchesQueryResult
            {
                Matches = matches
            };
        }
    }
}
