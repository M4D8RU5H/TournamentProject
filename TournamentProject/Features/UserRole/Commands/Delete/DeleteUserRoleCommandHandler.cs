using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TournamentProject.Features.User.Commands.Update;
using TournamentProject.Models;

namespace TournamentProject.Features.UserRole.Commands.Delete
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, DeleteUserRoleCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteUserRoleCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteUserRoleCommandResult> Handle(DeleteUserRoleCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteUserRoleCommandValidator();

            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == command.Id);

            if(userRole == null)
            {
                return null;
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return new DeleteUserRoleCommandResult();
        }
    }
}
