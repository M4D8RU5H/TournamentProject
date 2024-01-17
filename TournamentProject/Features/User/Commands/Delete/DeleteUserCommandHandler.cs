using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TournamentProject.Features.User.Commands.Update;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteUserCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteUserCommandResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteUserCommandValidator();

            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if(user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new DeleteUserCommandResult();
        }
    }
}
