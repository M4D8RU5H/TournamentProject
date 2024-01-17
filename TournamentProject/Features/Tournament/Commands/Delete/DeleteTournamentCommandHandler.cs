using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Tournament.Commands.Delete
{
    public class DeleteTournamentCommandHandler : IRequestHandler<DeleteTournamentCommand, DeleteTournamentCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteTournamentCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTournamentCommandResult> Handle(DeleteTournamentCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteTournamentCommandValidator();

            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == command.Id);

            if(tournament == null)
            {
                return null;
            }

            _context.Tournaments.Remove(tournament);

            await _context.SaveChangesAsync();

            return new DeleteTournamentCommandResult();
        }
    }
}
