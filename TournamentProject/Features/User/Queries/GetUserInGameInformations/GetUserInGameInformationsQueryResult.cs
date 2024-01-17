namespace TournamentProject.Features.User.Queries.GetUserInGameInformations
{
    public class GetUserInGameInformationsQueryResult
    {
        public List<PlayerQueueInfoDto> PlayerQueueInfo { get; set; }

        public class PlayerQueueInfoDto
        {
            public string QueueName { get; set; }
            public long LeaguePoints { get; set; }
            public string LeagueTier { get; set; }
            public string LeagueTierRank { get; set; }
            public long Winrate { get; set; }
            public long Wins { get; set; }
            public long Loses { get; set; }
            public long GamesPlayed { get; set; }

            public string DivisionLink { get; set; }
        }
    }
}
