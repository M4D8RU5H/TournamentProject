using MediatR;

namespace TournamentProject.Features.User.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserCommandResult>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
