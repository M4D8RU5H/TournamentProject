using FluentValidation;

namespace TournamentProject.Features.Message.Commands.Create
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            RuleFor(x => x.Content).Length(0, 750); 
        }
    }
}
