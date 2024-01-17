using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllUsersQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllUsersQueryResult> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _context.Users.Select(x => new GetAllUsersQueryResult.UserDto
            {
                Id = x.Id,
                Login = x.Login,
                Name = x.Name,
                Password = x.Password,
                RoleId = x.RoleId,
                BannedUntill = x.BannedUntill,
                Rank = x.Rank
            }).ToListAsync();

            return new GetAllUsersQueryResult
            {
                Users = users
            };
        }
    }
}
