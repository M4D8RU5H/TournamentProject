using MediatR;

namespace TournamentProject.Features.User.Queries.GetSingle
{
    public class GetSingleUserQuery : IRequest<GetSingleUserQueryResult>
    {
        public int Id { get; set; }

        public GetSingleUserQuery(int id)
        {
            Id = id;
        }
    }
}
