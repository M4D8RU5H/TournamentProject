namespace TournamentProject.Features.Team.Queries.GetSingle
{
    public class GetSingleTeamQueryResult
    {
        public TeamDto Team { get; set; }
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
