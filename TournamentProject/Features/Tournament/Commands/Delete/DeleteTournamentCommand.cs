using MediatR;

namespace TournamentProject.Features.Tournament.Commands.Delete
{
    public class DeleteTournamentCommand : IRequest<DeleteTournamentCommandResult>
    {
        public int Id { get; set; }

        public DeleteTournamentCommand(int id)
        {
            Id = id;
        }
    }
}
