using MediatR;

namespace TournamentProject.Features.Team.Commands.DeleteTeamMember
{
    public class DeleteTeamMemberCommand : IRequest<DeleteTeamMemberCommandResult>
    {
        public int TeamId { get; set; }

        public int UserId { get; set; }
    }
}
