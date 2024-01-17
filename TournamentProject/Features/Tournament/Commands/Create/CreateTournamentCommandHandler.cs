using FluentValidation;
using MediatR;
using TournamentProject.Models;

namespace TournamentProject.Features.Tournament.Commands.Create
{
    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, CreateTournamentCommandResult>
    {
        private readonly TournamentDbContext _context;

        public CreateTournamentCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<CreateTournamentCommandResult> Handle(CreateTournamentCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateTournamentCommandValidator();

            var result = validator.Validate(command);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var status = (int)Math.Log(command.MaxTeamAmount, 2);

            var tournament = new Models.Tournament()
            {
                Id = command.Id,
                Name = command.Name,
                TournamentDate = command.TournamentDate,
                MaxTeamAmount = command.MaxTeamAmount,
                Description = command.Description,
                RegistrationStarts = command.RegistrationStarts,
                RegistrationEnds = command.RegistrationEnds,
                Status = status,
                LiveTransmisionEmbed = command.LiveTransmisionEmbed,
            };

            _context.Tournaments.Add(tournament);

            await _context.SaveChangesAsync();

            return new CreateTournamentCommandResult();
        }
    }
}
