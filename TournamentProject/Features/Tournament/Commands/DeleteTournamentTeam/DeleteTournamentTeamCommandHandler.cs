using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Tournament.Commands.DeleteTournamentTeam
{
    public class DeleteTournamentTeamCommandHandler : IRequestHandler<DeleteTournamentTeamCommand, DeleteTournamentTeamCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteTournamentTeamCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTournamentTeamCommandResult> Handle(DeleteTournamentTeamCommand command, CancellationToken cancellationToken)
        {
            var tournament = _context.Tournaments
                .Include(x => x.Tournament_Teams)
                .Where(x => x.Id == command.TournamentId)
                .FirstOrDefault();

            if (tournament == null)
            {
                return null;
            }

            var teamToRemove = tournament.Tournament_Teams
                .Where(x => x.TeamId == command.TeamId && x.TournamentId == command.TournamentId)
                .FirstOrDefault();

            if(teamToRemove == null)
            {
                return null;
            }

            tournament.Tournament_Teams.Remove(teamToRemove);

            await _context.SaveChangesAsync();

            return new DeleteTournamentTeamCommandResult();
        }
    }
}
