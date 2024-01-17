using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Queries.GetByUserName
{
    public class GetByUserNameQueryHandler : IRequestHandler<GetByUserNameQuery, GetByUserNameQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetByUserNameQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }


        public async Task<GetByUserNameQueryResult> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .Where(x => x.Name.Contains(request.Phrase))
                .Select(x => new GetByUserNameQueryResult.UserDto
                {
                    Id = x.Id,
                    Login = x.Login,
                    Name = x.Name,
                    Password = x.Password,
                    RoleId = x.RoleId,
                    BannedUntill = x.BannedUntill,
                    Rank = x.Rank
                }).ToListAsync();

            return new GetByUserNameQueryResult
            {
                Users = users
            };
        }
    }
}
