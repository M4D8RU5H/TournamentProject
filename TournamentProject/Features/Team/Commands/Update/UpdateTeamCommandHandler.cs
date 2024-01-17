using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Team.Commands.Update
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, UpdateTeamCommandResult>
    {
        private readonly TournamentDbContext _context;

        public UpdateTeamCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateTeamCommandResult> Handle(UpdateTeamCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateTeamCommandValidator();

            var result = validator.Validate(command);

            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (team == null)
            {
                return null;
            }

            team.Name = command.Name;
            team.Ratio = command.Ratio;

            await _context.SaveChangesAsync();

            return new UpdateTeamCommandResult();
        }
    }
}
