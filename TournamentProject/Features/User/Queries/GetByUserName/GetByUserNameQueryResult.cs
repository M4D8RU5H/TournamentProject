namespace TournamentProject.Features.User.Queries.GetByUserName
{
    public class GetByUserNameQueryResult
    {
        public List<UserDto> Users { get; set; }
        public class UserDto
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public int RoleId { get; set; }
            public DateTime BannedUntill { get; set; }
            public string Rank { get; set; }
        }
    }
}
