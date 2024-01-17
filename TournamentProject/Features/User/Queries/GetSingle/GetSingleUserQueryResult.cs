using static TournamentProject.Features.User.Queries.GetAll.GetAllUsersQueryResult;

namespace TournamentProject.Features.User.Queries.GetSingle
{
    public class GetSingleUserQueryResult
    {
        public UserDto User { get; set; }
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
