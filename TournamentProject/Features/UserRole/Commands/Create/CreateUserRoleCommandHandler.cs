using FluentValidation;
using MediatR;
using TournamentProject.Models;

namespace TournamentProject.Features.UserRole.Commands.Create
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, CreateUserRoleCommandResult>
    {
        private readonly TournamentDbContext _context;

        public CreateUserRoleCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<CreateUserRoleCommandResult> Handle(CreateUserRoleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateUserRoleCommandValidator();

            var result = validator.Validate(command);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var userRole = new Models.UserRole()
            {
                Name = command.Name
            };

            _context.UserRoles.Add(userRole);

            await _context.SaveChangesAsync();

            return new CreateUserRoleCommandResult();
        }
    }
}
