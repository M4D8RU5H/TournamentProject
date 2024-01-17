using FluentValidation;

namespace TournamentProject.Features.Comment.Commands.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Content).NotNull().NotEmpty().Length(1, 200);
        }
    }
}
