using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Tournament.Commands.Update
{
    public class UpdateTournamentCommandHandler : IRequestHandler<UpdateTournamentCommand, UpdateTournamentCommandResult>
    {
        private readonly TournamentDbContext _context;

        public UpdateTournamentCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateTournamentCommandResult> Handle(UpdateTournamentCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateTournamentCommandValidator();

            var result = validator.Validate(command);

            var tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (tournament == null)
            {
                return null;
            }

            tournament.Name = command.Name;
            tournament.TournamentDate = command.TournamentDate;
            tournament.MaxTeamAmount = command.MaxTeamAmount;
            tournament.Description = command.Description;
            tournament.RegistrationStarts = command.RegistrationStarts;
            tournament.RegistrationEnds = command.RegistrationEnds;
            tournament.Status = command.Status;
            tournament.LiveTransmisionEmbed = command.LiveTransmisionEmbed;

            await _context.SaveChangesAsync();

            return new UpdateTournamentCommandResult();
        }
    }
}
