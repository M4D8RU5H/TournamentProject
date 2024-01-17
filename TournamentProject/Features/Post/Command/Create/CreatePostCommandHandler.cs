using MediatR;
using TournamentProject.Models;

namespace TournamentProject.Features.Post.Command.Create;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResult>
{
    private readonly TournamentDbContext _context;

    public CreatePostCommandHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<CreatePostCommandResult> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var post = new Models.Post()
        {
            UserId = command.UserId,
            Content = command.Content,
            Date = DateTime.Now,
            Title = command.Title,
        };

        _context.Add(post);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreatePostCommandResult();
    }
}