using MediatR;

namespace TournamentProject.Features.Team.Commands.Delete
{
    public class DeleteTeamCommand : IRequest<DeleteTeamCommandResult>
    {
        public int Id { get; set; }

        public DeleteTeamCommand(int id)
        {
            Id = id;
        }
    }
}
