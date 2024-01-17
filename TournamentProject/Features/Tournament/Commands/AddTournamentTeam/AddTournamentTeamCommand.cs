using MediatR;

namespace TournamentProject.Features.Tournament.Commands.AddTournamentTeam
{
    public class AddTournamentTeamCommand : IRequest<AddTournamentTeamCommandResult>
    {
        public int TournamentId { get; set; }

        public int TeamId { get; set; }
    }
}
