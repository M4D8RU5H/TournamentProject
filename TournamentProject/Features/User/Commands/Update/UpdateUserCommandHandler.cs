using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Xml.Linq;
using RiotSharp;
using RiotSharp.Misc;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResult>
    {
        private readonly TournamentDbContext _context;
        
        private readonly IConfiguration _config;

        public UpdateUserCommandHandler(TournamentDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<UpdateUserCommandResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidator();

            var result = validator.Validate(command);

            string summonerDivision;

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

            if (user == null)
            {
                return null;
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

            user.Id = command.Id;
            user.Login = command.Login;
            user.Name = command.Name;
            user.Password = command.Password;
            user.RoleId = command.RoleId;
            user.BannedUntill = command.BannedUntill;
            user.Rank = summonerDivision;

            await _context.SaveChangesAsync();

            return new UpdateUserCommandResult();
        }
    }
}
