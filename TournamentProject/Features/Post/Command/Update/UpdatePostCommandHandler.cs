using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Post.Command.Update;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostCommandResult>
{
    private readonly TournamentDbContext _context;

    public UpdatePostCommandHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<UpdatePostCommandResult> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var post = await _context.Posts.Where(x => x.Id == command.Id).FirstOrDefaultAsync(cancellationToken);

        if (post == null)
        {
            return null;
        }

        post.Title = command.Title;
        post.Content = command.Content;
        post.Date = DateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdatePostCommandResult();
    }
}