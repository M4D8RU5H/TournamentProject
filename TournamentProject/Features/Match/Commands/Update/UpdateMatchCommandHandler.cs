using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Match.Command.Update;

public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand, UpdateMatchCommandResult>
{
    private readonly TournamentDbContext _context;

    public UpdateMatchCommandHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateMatchCommandResult> Handle(UpdateMatchCommand command, CancellationToken cancellationToken)
    {
        var match = await _context.Matches.Where(x => x.Id == command.Id).FirstOrDefaultAsync(cancellationToken);

        if (match == null)
        {
            return null;
        }

        match.Id = command.Id;
        match.FirstTeamId = command.FirstTeamId;
        match.SecondTeamId = command.SecondTeamId;
        match.WinnerId = command.WinnerId;
        match.Score = command.Score;
        match.TournamentId = command.TournamentId;
        match.Phase = command.Phase;

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateMatchCommandResult();
    }
}