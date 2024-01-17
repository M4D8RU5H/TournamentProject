using MediatR;

namespace TournamentProject.Features.Comment.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<DeleteCommentCommandResult>
    {
        public int Id { get; set; }

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
