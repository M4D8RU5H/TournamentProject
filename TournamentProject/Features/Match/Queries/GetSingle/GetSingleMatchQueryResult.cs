namespace TournamentProject.Features.Match.Queries.GetSingle
{
    public class GetSingleMatchQueryResult
    {
        public MatchDto Match { get; set; }
        public class MatchDto
        {
            public int Id { get; set; }
            public int FirstTeamId { get; set; }
            public int SecondTeamId { get; set; }
            public int? WinnerId { get; set; }
            public int Score { get; set; }
            public int TournamentId { get; set; }
            public int Phase { get; set; }
        }
    }
}
