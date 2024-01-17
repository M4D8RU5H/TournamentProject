using MediatR;

namespace TournamentProject.Features.Post.Command.Create;

public class CreatePostCommand : IRequest<CreatePostCommandResult>
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public string Content { get; set; }

    public string Title { get; set; }
}