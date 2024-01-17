using MediatR;

namespace TournamentProject.Features.Post.Command.Update;

public class UpdatePostCommand : IRequest<UpdatePostCommandResult>
{
    public int Id { get; set; }

    public string Content { get; set; }

    public string Title { get; set; }
}