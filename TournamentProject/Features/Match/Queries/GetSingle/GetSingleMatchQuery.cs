using MediatR;

namespace TournamentProject.Features.Match.Queries.GetSingle
{
    public class GetSingleMatchQuery : IRequest<GetSingleMatchQueryResult>
    {
        public int Id { get; set; }

        public GetSingleMatchQuery(int id)
        {
            Id = id;
        }
    }
}
