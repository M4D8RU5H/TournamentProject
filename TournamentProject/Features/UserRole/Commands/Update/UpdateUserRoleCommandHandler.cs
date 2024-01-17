using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Xml.Linq;
using TournamentProject.Models;

namespace TournamentProject.Features.UserRole.Commands.Update
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, UpdateUserRoleCommandResult>
    {
        private readonly TournamentDbContext _context;

        public UpdateUserRoleCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateUserRoleCommandResult> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserRoleCommandValidator();

            var result = validator.Validate(command);

            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (userRole == null)
            {
                return null;
            }

            userRole.Id = command.Id;
            userRole.Name = command.Name;

            await _context.SaveChangesAsync();

            return new UpdateUserRoleCommandResult();
        }
    }
}
