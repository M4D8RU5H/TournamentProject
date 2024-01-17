using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TournamentProject.Features.Comment.Queries.GetAll
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, GetAllCommentsQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllCommentsQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllCommentsQueryResult> Handle(GetAllCommentsQuery query, CancellationToken cancellationToken)
        {
            var comments = await _context.Comments.Select(x => new GetAllCommentsQueryResult.CommentDto
            {
                Id = x.Id,
                Content = x.Content,
                PostId = x.PostId,
                UserId = x.UserId,
                CommentDate = x.CommentDate,
            }).ToListAsync();

            return new GetAllCommentsQueryResult
            {
                Comments = comments
            };
        }
    }
}
