namespace TournamentProject.Features.Team.Queries.GetUserTeams
{
    public class GetUserTeamsQueryResult
    {
        public List<TeamDto> Teams { get; set; }

        public class TeamDto 
        {
            public int Id { get; set; }

            public string TeamName { get; set; }
        }
    }
}
