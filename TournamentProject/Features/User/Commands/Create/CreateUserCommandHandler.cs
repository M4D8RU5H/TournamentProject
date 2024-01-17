using FluentValidation;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RiotSharp;
using RiotSharp.Misc;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
    {
        private readonly TournamentDbContext _context;
        
        private readonly IConfiguration _config;

        public CreateUserCommandHandler(TournamentDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<CreateUserCommandResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();

            var result = validator.Validate(command);

            string summonerDivision;

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            
            var riotApi = RiotApi.GetDevelopmentInstance(_config.GetSection("RiotApiKey").Value);

            try
            {
                var summoner = riotApi.Summoner.GetSummonerByNameAsync(Region.Eune, command.Name).Result;
                var summonerDivisionInfo =
                    riotApi.League.GetLeagueEntriesBySummonerAsync(Region.Eune, summoner.Id).Result;

                var soloQueue = summonerDivisionInfo.Where(x => x.QueueType == "RANKED_SOLO_5x5").FirstOrDefault();

                summonerDivision = (soloQueue != null) ? soloQueue.Tier + " " + soloQueue.Rank : null;
            }
            catch
            {
                throw;
            }

            var user = new Models.User()
            {
                Id = command.Id,
                Login = command.Login,
                Name = command.Name,
                Password = command.Password,
                RoleId = command.RoleId,
                Rank = string.IsNullOrEmpty(summonerDivision) ? "UNRANKED" : summonerDivision
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return new CreateUserCommandResult();
        }
    }
}
