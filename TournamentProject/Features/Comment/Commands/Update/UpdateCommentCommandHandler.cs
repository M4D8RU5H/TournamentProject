using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Comment.Commands.Update
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentCommandResult>
    {
        private readonly TournamentDbContext _context;

        public UpdateCommentCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateCommentCommandResult> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentCommandValidator();

            var result = validator.Validate(command);

            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (comment == null)
            {
                return null;
            }

            comment.Id = command.Id;
            comment.Content = command.Content;
            comment.PostId = command.PostId;
            comment.UserId = command.UserId;
            comment.CommentDate = command.CommentDate;

            await _context.SaveChangesAsync();

            return new UpdateCommentCommandResult();
        }
    }
}
