using static TournamentProject.Features.UserRole.Queries.GetAll.GetAllUserRolesQueryResult;

namespace TournamentProject.Features.UserRole.Queries.GetSingle
{
    public class GetSingleUserRoleQueryResult
    {
        public UserRoleDto UserRole { get; set; }
        public class UserRoleDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
