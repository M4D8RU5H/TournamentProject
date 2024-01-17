using MediatR;
using TournamentProject.Models;

namespace TournamentProject.Features.Comment.Commands.Create
{
    public class CreateCommentCommand : IRequest<CreateCommentCommandResult>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
