using MediatR;

namespace TournamentProject.Features.Message.Queries.GetSingle
{
    public class GetSingleMessageQuery : IRequest<GetSingleMessageQueryResult>
    {
        public int Id { get; set; }

        public GetSingleMessageQuery(int id)
        {
            Id = id;
        }
    }
}
