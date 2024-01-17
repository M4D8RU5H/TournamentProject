using MediatR;

namespace TournamentProject.Features.UserRole.Queries.GetSingle
{
    public class GetSingleUserRoleQuery : IRequest<GetSingleUserRoleQueryResult>
    {
        public int Id { get; set; }

        public GetSingleUserRoleQuery(int id)
        {
            Id = id;
        }
    }
}
