namespace TournamentProject.Features.UserRole.Queries.GetAll
{
    public class GetAllUserRolesQueryResult
    {
        public List<UserRoleDto> UserRoles { get; set; }
        public class UserRoleDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
