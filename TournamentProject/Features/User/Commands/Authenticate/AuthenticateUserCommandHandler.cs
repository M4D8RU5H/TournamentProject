
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Commands.Authenticate
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserCommandResult>
    {
        private readonly TournamentDbContext _context;

        public AuthenticateUserCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<AuthenticateUserCommandResult> Handle(AuthenticateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(x => x.Login == command.Email).Where(x => x.Password == command.Password).FirstOrDefaultAsync();

            if(user == null)
            {
                return null;
            }

            return new AuthenticateUserCommandResult()
            {
                Id = user.Id,
                Name = user.Login
            };
        }
    }
}
