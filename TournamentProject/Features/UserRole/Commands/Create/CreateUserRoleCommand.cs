using MediatR;

namespace TournamentProject.Features.UserRole.Commands.Create
{
    public class CreateUserRoleCommand : IRequest<CreateUserRoleCommandResult>
    {
        public string Name { get; set; }
    }
}
