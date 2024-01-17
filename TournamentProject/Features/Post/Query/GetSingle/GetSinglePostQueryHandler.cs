using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Post.Query.GetAll;
using TournamentProject.Models;

namespace TournamentProject.Features.Post.Query.GetSingle;

public class GetSinglePostQueryHandler : IRequestHandler<GetSinglePostQuery, GetSinglePostQueryResult>
{
    private readonly TournamentDbContext _context;

    public GetSinglePostQueryHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<GetSinglePostQueryResult> Handle(GetSinglePostQuery request, CancellationToken cancellationToken)
    {
        var post = await _context.Posts.Where(x => x.Id == request.Id).Select(x => new GetSinglePostQueryResult.PostDto
        {
            Id = x.Id,
            User = _context.Users.Where(y => y.Id == x.UserId).Select(y => new GetSinglePostQueryResult.UserDto
            {
                Id = y.Id,
                Name = y.Name
            }).FirstOrDefault(),
            Title = x.Title,
            Content = x.Content,
            Date = x.Date,
            Comments =  x.Comments.Select(z => new GetSinglePostQueryResult.CommentsDto
            {
                Id = z.Id,
                CommentAuthor = _context.Users.Where(y => y.Id == z.UserId).Select(y => new GetSinglePostQueryResult.UserDto
                {
                    Id = y.Id,
                    Name = y.Name
                }).FirstOrDefault(),
                Content = z.Content,
                CommentDate = z.CommentDate
            }).ToList()
        }).FirstOrDefaultAsync(cancellationToken);

        return new GetSinglePostQueryResult()
        {
            Post = post
        };
    }
}