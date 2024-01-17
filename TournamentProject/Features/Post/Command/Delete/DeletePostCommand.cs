using MediatR;

namespace TournamentProject.Features.Post.Command.Delete;

public class DeletePostCommand : IRequest<DeletePostCommandResult>
{
    public int Id { get; set; }
}