namespace TournamentProject.Features.User.Queries.GetUserMatchHistory
{
    public class GetUserMatchHistoryQueryResult
    {
        public List<PlayerMatchDetailsDto> PlayerMatchDetails { get; set; }

        public class PlayerMatchDetailsDto
        {
            public string GameType { get; set; }
            public string GameLength { get; set; }
            public DateTime GameDate { get; set; }
            public Boolean Win { get; set; }
            public string ChampName { get; set; }
            public string ChampIconUrl { get; set; }
            public long ChampLevel { get; set; }
            public long Kills { get; set; }
            public long Assists { get; set; }
            public long Deaths { get; set; }
            public float KDA { get; set; }
            public long MinionsKilled { get; set; }
            public long GoldEarned { get; set; }

            public List<ItemPathDto> ItemPathList { get; set; }
        }

        public class ItemPathDto
        {
            public string ItemPath { get; set; }
        }
    }
}
