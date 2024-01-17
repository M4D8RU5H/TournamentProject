using FluentValidation;

namespace TournamentProject.Features.Comment.Commands.Delete
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
