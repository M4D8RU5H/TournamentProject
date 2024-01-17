using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TournamentProject.Models;

namespace TournamentProject.Features.Team.Commands.Create
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, CreateTeamCommandResult>
    {
        private readonly TournamentDbContext _context;

        public CreateTeamCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<CreateTeamCommandResult> Handle(CreateTeamCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateTeamCommandValidator();

            var result = validator.Validate(command);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var team = new Models.Team()
            {
                Id = command.Id,
                Name = command.Name,
                Ratio = command.Ratio,
                Team_Users = new List<TeamUser>
                {
                    new TeamUser
                    {
                        UserId = command.TeamLeaderId,
                    }
                }
            };
            
            _context.Teams.Add(team);
            
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateTeamCommandResult();
        }
    }
}
