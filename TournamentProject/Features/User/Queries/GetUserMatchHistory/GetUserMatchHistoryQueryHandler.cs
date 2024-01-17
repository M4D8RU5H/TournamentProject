using MediatR;
using RiotSharp;
using RiotSharp.Misc;
using TournamentProject.Models;
using static System.Net.WebRequestMethods;
using static TournamentProject.Features.User.Queries.GetUserMatchHistory.GetUserMatchHistoryQueryResult;

namespace TournamentProject.Features.User.Queries.GetUserMatchHistory
{
    public class GetUserMatchHistoryQueryHandler : IRequestHandler<GetUserMatchHistoryQuery, GetUserMatchHistoryQueryResult>
    {
        private readonly TournamentDbContext _context;
        private readonly IConfiguration _config;

        public GetUserMatchHistoryQueryHandler(TournamentDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<GetUserMatchHistoryQueryResult> Handle(GetUserMatchHistoryQuery request, CancellationToken cancellationToken)
        {
            var itemPath = "https://ddragon.leagueoflegends.com/cdn/13.11.1/img/item/";

            var championPath = "https://ddragon.leagueoflegends.com/cdn/13.11.1/img/champion/";

            var user = _context.Users.FirstOrDefault(x => x.Id == request.UserId);

            var riotApi = RiotApi.GetDevelopmentInstance(_config.GetSection("RiotApiKey").Value);

            var summoner = await riotApi.Summoner.GetSummonerByNameAsync(Region.Eune, user.Name);

            var summonerLast20MatchesId = await riotApi.Match.GetMatchListAsync(Region.Europe, summoner.Puuid);

            var matchList = new List<PlayerMatchDetailsDto>();

            foreach (var singleMatchId in summonerLast20MatchesId)
            {
                var match = await riotApi.Match.GetMatchAsync(Region.Europe, singleMatchId);
                var matchDetails = match.Info.Participants.FirstOrDefault(x => x.Puuid == summoner.Puuid);

                var itemsPaths = new List<string> {
                $"{itemPath}{matchDetails.Item0}.png",
                $"{itemPath}{matchDetails.Item1}.png",
                $"{itemPath}{matchDetails.Item2}.png",
                $"{itemPath}{matchDetails.Item3}.png",
                $"{itemPath}{matchDetails.Item4}.png",
                $"{itemPath}{matchDetails.Item5}.png",
                $"{itemPath}{matchDetails.Item6}.png"
                };

                itemsPaths = itemsPaths.Select(path => path.Replace($"{itemPath}0.png", "noItem")).ToList();

                var itemsPathList = itemsPaths.Select(path => new ItemPathDto { ItemPath = path }).ToList();

                var playerMatchDetails = new GetUserMatchHistoryQueryResult.PlayerMatchDetailsDto
                {
                    GameType = match.Info.GameMode,
                    GameLength = $"{match.Info.GameDuration.Minutes}:{match.Info.GameDuration.Seconds:D2}",
                    GameDate = match.Info.GameCreation,
                    Win = matchDetails.Winner,
                    ChampName = matchDetails.ChampionName,
                    ChampIconUrl = $"{championPath}{matchDetails.ChampionName}.png",
                    ChampLevel = matchDetails.ChampLevel,
                    Kills = matchDetails.Kills,
                    Deaths = matchDetails.Deaths,
                    Assists = matchDetails.Assists,
                    KDA = (matchDetails.Kills + matchDetails.Assists) / matchDetails.Deaths,
                    GoldEarned = matchDetails.GoldEarned,
                    MinionsKilled = matchDetails.TotalMinionsKilled,
                    ItemPathList = itemsPathList,
                };

                matchList.Add(playerMatchDetails);
            }

            return new GetUserMatchHistoryQueryResult
            {
                PlayerMatchDetails = matchList
            };
        }
    }
}
