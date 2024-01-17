using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Post.Query.GetAll;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostsQueryResult>
{
    private readonly TournamentDbContext _context;

    public GetAllPostsQueryHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<GetAllPostsQueryResult> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _context.Posts.Select(x => new GetAllPostsQueryResult.PostDto
        {
            Id = x.Id,
            User =  new GetAllPostsQueryResult.UserDto
            {
                Id = x.User.Id,
                Name = x.User.Name
            },
            Title = x.Title,
            Content = x.Content,
            Date = x.Date,
            Comments =  x.Comments.Select(z => new GetAllPostsQueryResult.CommentsDto
            {
                Id = z.Id,
                CommentAuthor = new GetAllPostsQueryResult.UserDto
                {
                    Id = z.User.Id,
                    Name = z.User.Name
                },
                Content = z.Content,
                CommentDate = z.CommentDate
            }).ToList()
        }).ToListAsync(cancellationToken);

        return new GetAllPostsQueryResult()
        {
            Posts = posts
        };
    }
}