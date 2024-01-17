using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Team.Commands.DeleteTeamMember
{
    public class DeleteTeamMemberCommandHandler : IRequestHandler<DeleteTeamMemberCommand, DeleteTeamMemberCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteTeamMemberCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteTeamMemberCommandResult> Handle(DeleteTeamMemberCommand command, CancellationToken cancellationToken)
        {
            var team = _context.Teams.Include(x => x.Team_Users).FirstOrDefault(x => x.Id == command.TeamId);

            if (team == null)
            {
                return null;
            }

            var teamUserRecord = team.Team_Users
                .Where(x => x.TeamId == command.TeamId && x.UserId == command.UserId)
                .FirstOrDefault();

            team.Team_Users.Remove(teamUserRecord);

            await _context.SaveChangesAsync();

            return new DeleteTeamMemberCommandResult();
        }
    }
}
