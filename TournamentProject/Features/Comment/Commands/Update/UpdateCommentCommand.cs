using MediatR;

namespace TournamentProject.Features.Comment.Commands.Update
{
    public class UpdateCommentCommand : IRequest<UpdateCommentCommandResult>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
