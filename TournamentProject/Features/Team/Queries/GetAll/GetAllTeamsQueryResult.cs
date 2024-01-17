namespace TournamentProject.Features.Team.Queries.GetAll
{
    public class GetAllTeamsQueryResult
    {
        public List<TeamDto> Teams { get; set; }
        public class TeamDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Ratio { get; set; }

            public List<UserDto> TeamMembers { get; set; }
        }

        public class UserDto
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Rank { get; set; }
        }
    }
}
