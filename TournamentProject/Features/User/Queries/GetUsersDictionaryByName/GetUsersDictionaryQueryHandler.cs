using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.User.Queries.GetByUserName;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Queries.GetUsersDictionaryByName
{
    public class GetUsersDictionaryQueryHandler : IRequestHandler<GetUsersDictionaryQuery, GetUsersDictionaryQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetUsersDictionaryQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetUsersDictionaryQueryResult> Handle(GetUsersDictionaryQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .Select(x => new GetUsersDictionaryQueryResult.UserDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return new GetUsersDictionaryQueryResult
            {
                Users = users
            };
        }
    }
}
