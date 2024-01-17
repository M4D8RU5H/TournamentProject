using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using TournamentProject.Features.Tournament.Queries.GetAll;
using TournamentProject.Models;

namespace TournamentProject.Features.Tournament.Queries.GetTournamentTeams;

public class GetTournamentTeamsQueryHandler : IRequestHandler<GetTournamentTeamsQuery, GetTournamentTeamsQueryResult>
{
    private readonly TournamentDbContext _context;

    public GetTournamentTeamsQueryHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<GetTournamentTeamsQueryResult> Handle(GetTournamentTeamsQuery request,
        CancellationToken cancellationToken)
    {
        var tournament = await _context.Tournaments
            .Include(x => x.Tournament_Teams)
            .ThenInclude(x => x.Team)
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        var teams = tournament.Tournament_Teams
            .Select(x => new GetTournamentTeamsQueryResult.TeamDto()
            {
                Id = x.Team.Id,
                Name = x.Team.Name,
                Ratio = x.Team.Ratio,
            }).ToList();

        await _context.SaveChangesAsync(cancellationToken);
        
        return new GetTournamentTeamsQueryResult()
        {
            Teams = teams
        };

    }
}