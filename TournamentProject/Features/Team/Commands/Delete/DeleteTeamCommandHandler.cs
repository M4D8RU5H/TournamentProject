using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TournamentProject.Features.Team.Commands.Update;
using TournamentProject.Models;

namespace TournamentProject.Features.Team.Commands.Delete
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, DeleteTeamCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteTeamCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTeamCommandResult> Handle(DeleteTeamCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteTeamCommandValidator();

            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == command.Id);

            if(team == null)
            {
                return null;
            }

            _context.Teams.Remove(team);

            _context.SaveChangesAsync();

            return new DeleteTeamCommandResult();
        }
    }
}
