using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Team.Commands.AddTeamMember
{
    public class AddTeamMemberCommandHandler : IRequestHandler<AddTeamMemberCommand, AddTeamMemberCommandResult>
    {
        private readonly TournamentDbContext _context;

        public AddTeamMemberCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<AddTeamMemberCommandResult> Handle(AddTeamMemberCommand command, CancellationToken cancellationToken)
        {
            var team = _context.Teams
                .Include(x => x.Team_Users)
                .FirstOrDefault(x => x.Id == command.TeamId);

            if (team == null)
            {
                return null;
            }

            if(team.Team_Users.Count() <=5)
            {
                team.Team_Users.Add(new TeamUser()
                {
                    UserId = command.UserId
                });
            }

            await _context.SaveChangesAsync();

            return new AddTeamMemberCommandResult();
        }
    }
}
