using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Tournament.Commands.AddTournamentTeam
{
    public class AddTournamentTeamCommandHandler : IRequestHandler<AddTournamentTeamCommand, AddTournamentTeamCommandResult>
    {
        private readonly TournamentDbContext _context;

        public AddTournamentTeamCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<AddTournamentTeamCommandResult> Handle(AddTournamentTeamCommand command, CancellationToken cancellationToken)
        {
            var tournament = _context.Tournaments
                .Include(x => x.Tournament_Teams)
                .Where(x => x.Id == command.TournamentId)
                .FirstOrDefault();

            if (tournament == null)
            {
                return null;
            }

            var team = _context.Teams.FirstOrDefault(x => x.Id == command.TeamId);

            if(tournament.Tournament_Teams.Count() < tournament.MaxTeamAmount)
            {
                tournament.Tournament_Teams.Add(new TournamentTeam()
                {
                    TeamId = command.TeamId
                });
            }

            await _context.SaveChangesAsync();

            return new AddTournamentTeamCommandResult();
        }
    }
}
