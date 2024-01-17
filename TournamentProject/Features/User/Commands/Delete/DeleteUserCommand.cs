using MediatR;

namespace TournamentProject.Features.User.Commands.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserCommandResult>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
