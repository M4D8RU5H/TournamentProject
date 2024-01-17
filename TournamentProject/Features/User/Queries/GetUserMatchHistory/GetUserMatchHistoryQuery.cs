using MediatR;

namespace TournamentProject.Features.User.Queries.GetUserMatchHistory
{
    public class GetUserMatchHistoryQuery : IRequest<GetUserMatchHistoryQueryResult>
    {
        public GetUserMatchHistoryQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
