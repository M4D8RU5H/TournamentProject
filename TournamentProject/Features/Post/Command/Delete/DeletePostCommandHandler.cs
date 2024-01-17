using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Post.Command.Delete;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletePostCommandResult>
{
    private readonly TournamentDbContext _context;

    public DeletePostCommandHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<DeletePostCommandResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _context.Posts.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

        if (post == null)
        {
            return null;
        }

        _context.Remove(post);
        await _context.SaveChangesAsync(cancellationToken);

        return new DeletePostCommandResult();
    }
}