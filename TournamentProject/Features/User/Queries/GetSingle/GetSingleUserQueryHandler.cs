using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiotSharp;
using RiotSharp.Misc;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Queries.GetSingle
{
    public class GetSingleUserQueryHandler : IRequestHandler<GetSingleUserQuery, GetSingleUserQueryResult>
    {
        private readonly TournamentDbContext _context;

        private readonly IConfiguration _config;

        public GetSingleUserQueryHandler(TournamentDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<GetSingleUserQueryResult> Handle(GetSingleUserQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSingleUserQueryValidator();

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (user == null)
            {
                return null;
            }

            var riotApi = RiotApi.GetDevelopmentInstance(_config.GetSection("RiotApiKey").Value);

            var summoner = riotApi.Summoner.GetSummonerByNameAsync(Region.Eune, user.Name).Result;

            return new GetSingleUserQueryResult
            {
                User = new GetSingleUserQueryResult.UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Name = user.Name,
                    Password = user.Password,
                    RoleId = user.RoleId,
                    BannedUntill = user.BannedUntill,
                    Rank = user.Rank,
                }
            };
        }
    }
}
