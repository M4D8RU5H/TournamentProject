using MediatR;

namespace TournamentProject.Features.Tournament.Commands.DeleteTournamentTeam
{
    public class DeleteTournamentTeamCommand : IRequest<DeleteTournamentTeamCommandResult>
    {
        public int TournamentId { get; set; }

        public int TeamId { get; set; }
    }
}
