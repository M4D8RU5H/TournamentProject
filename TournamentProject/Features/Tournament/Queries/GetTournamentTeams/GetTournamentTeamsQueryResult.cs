namespace TournamentProject.Features.Tournament.Queries.GetTournamentTeams;

public class GetTournamentTeamsQueryResult
{
    public List<TeamDto> Teams { get; set; }
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ratio { get; set; }
    }
}