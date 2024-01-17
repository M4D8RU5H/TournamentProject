using FluentValidation;
using MediatR;
using TournamentProject.Models;

namespace TournamentProject.Features.Message.Commands.Create
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, CreateMessageCommandResult>
    {
        private readonly TournamentDbContext _context;

        public CreateMessageCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<CreateMessageCommandResult> Handle(CreateMessageCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateMessageCommandValidator();

            var result = validator.Validate(command);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var team = new Models.Message()
            {
                Id = command.Id,
                SenderId = command.SenderId,
                ReceiverId = command.ReceiverId,
                Content = command.Content,
                Readed = command.Readed,
            };

            _context.Messages.Add(team);

            await _context.SaveChangesAsync();

            return new CreateMessageCommandResult();
        }
    }
}
