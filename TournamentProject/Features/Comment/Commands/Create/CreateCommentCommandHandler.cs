using FluentValidation;
using MediatR;
using TournamentProject.Models;

namespace TournamentProject.Features.Comment.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentCommandResult>
    {
        private readonly TournamentDbContext _context;

        public CreateCommentCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCommentCommandResult> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCommentCommandValidator();

            var result = validator.Validate(command);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var comment = new Models.Comment()
            {
                Id = command.Id,
                Content = command.Content,
                PostId = command.PostId,
                UserId = command.UserId,
                CommentDate = command.CommentDate,
            };

            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();

            return new CreateCommentCommandResult();
        }
    }
}
