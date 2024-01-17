using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.UserRole.Queries.GetAll
{
    public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, GetAllUserRolesQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllUserRolesQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllUserRolesQueryResult> Handle(GetAllUserRolesQuery query, CancellationToken cancellationToken)
        {
            var userRoles = await _context.UserRoles.Select(x => new GetAllUserRolesQueryResult.UserRoleDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return new GetAllUserRolesQueryResult
            {
                UserRoles = userRoles
            };
        }
    }
}
