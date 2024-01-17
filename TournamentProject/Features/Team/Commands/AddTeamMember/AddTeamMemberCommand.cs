using MediatR;

namespace TournamentProject.Features.Team.Commands.AddTeamMember
{
    public class AddTeamMemberCommand : IRequest<AddTeamMemberCommandResult>
    {
        public int TeamId { get; set; }

        public int UserId { get; set; }
    }
}
