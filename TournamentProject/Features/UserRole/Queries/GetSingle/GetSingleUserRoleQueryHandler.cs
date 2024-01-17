using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TournamentProject.Features.UserRole.Queries.GetSingle
{
    public class GetSingleUserRoleQueryHandler : IRequestHandler<GetSingleUserRoleQuery, GetSingleUserRoleQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetSingleUserRoleQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleUserRoleQueryResult> Handle(GetSingleUserRoleQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSingleUserRoleQueryValidator();

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var userRoles = await _context.Users.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (userRoles == null)
            {
                return null;
            }

            var userRoleDTO = new GetSingleUserRoleQueryResult.UserRoleDto
            {
                Id = userRoles.Id,
                Name = userRoles.Name
            };

            return new GetSingleUserRoleQueryResult
            {
                UserRole = userRoleDTO
            };
        }
    }
}
