using FluentValidation;

namespace TournamentProject.Features.Comment.Commands.Update
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Content).NotNull().NotEmpty().Length(1, 200);
        }
    }
}
