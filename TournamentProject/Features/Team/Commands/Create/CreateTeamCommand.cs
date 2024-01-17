using MediatR;

namespace TournamentProject.Features.Team.Commands.Create
{
    public class CreateTeamCommand : IRequest<CreateTeamCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ratio { get; set; }

        public int TeamLeaderId { get; set; }
    }
}
