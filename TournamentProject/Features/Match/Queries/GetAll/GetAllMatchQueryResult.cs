namespace TournamentProject.Features.Match.Queries.GetAll
{
    public class GetAllMatchesQueryResult
    {
        public List<MatchDto> Matches { get; set; }
        public class MatchDto
        {
            public int Id { get; set; }
            public int FirstTeamId { get; set; }
            public string FirstTeamName { get; set; }
            public int SecondTeamId { get; set; }
            public string SecondTeamName { get; set; }
            public int? WinnerId { get; set; }
            public int Score { get; set; }
            public int TournamentId { get; set; }
            public int Phase { get; set; }
        }
    }
}
