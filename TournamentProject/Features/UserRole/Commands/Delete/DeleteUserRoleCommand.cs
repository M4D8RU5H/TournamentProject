using MediatR;

namespace TournamentProject.Features.UserRole.Commands.Delete
{
    public class DeleteUserRoleCommand : IRequest<DeleteUserRoleCommandResult>
    {
        public int Id { get; set; }

        public DeleteUserRoleCommand(int id)
        {
            Id = id;
        }
    }
}
