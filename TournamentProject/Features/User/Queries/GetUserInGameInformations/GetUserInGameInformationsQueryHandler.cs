using MediatR;
using RiotSharp;
using RiotSharp.Misc;
using TournamentProject.Features.User.Queries.GetSingle;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Queries.GetUserInGameInformations
{
    public class GetUserInGameInformationsQueryHandler : IRequestHandler<GetUserInGameInformationsQuery, GetUserInGameInformationsQueryResult>
    {
        private readonly TournamentDbContext _context;
        private readonly IConfiguration _config;

        public GetUserInGameInformationsQueryHandler(TournamentDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<GetUserInGameInformationsQueryResult> Handle(GetUserInGameInformationsQuery request, CancellationToken cancellationToken)
        {
            var divisionPath = "https://ddragon.leagueoflegends.com/cdn/13.1.1/img/tft-regalia/TFT_Regalia_";

            var user = _context.Users.FirstOrDefault(x => x.Id == request.UserId);

            var riotApi = RiotApi.GetDevelopmentInstance(_config.GetSection("RiotApiKey").Value);

            var summoner = await riotApi.Summoner.GetSummonerByNameAsync(Region.Eune, user.Name);

            var summonerQueue = await riotApi.League.GetLeagueEntriesBySummonerAsync(Region.Eune, summoner.Id);

            var summonerQueueDetails = summonerQueue.Select(x => new GetUserInGameInformationsQueryResult.PlayerQueueInfoDto
            {
                QueueName = x.QueueType,
                LeagueTier = x.Tier,
                LeagueTierRank = x.Rank,
                LeaguePoints = x.LeaguePoints,
                Wins = x.Wins,
                Loses = x.Losses,
                GamesPlayed = x.Wins + x.Losses,
                Winrate = (x.Wins / (x.Wins + x.Losses)) * 100,
                DivisionLink = $"{divisionPath}{char.ToUpperInvariant(x.Tier[0])}{x.Tier.Substring(1).ToLowerInvariant()}.png"
            }).ToList();

            return new GetUserInGameInformationsQueryResult
            {
                PlayerQueueInfo = summonerQueueDetails
            };
        }
    }
}
