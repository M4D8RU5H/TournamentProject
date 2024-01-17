using MediatR;

namespace TournamentProject.Features.User.Commands.Authenticate
{
    public class AuthenticateUserCommand : IRequest<AuthenticateUserCommandResult>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
