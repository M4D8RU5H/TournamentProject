using MediatR;

namespace TournamentProject.Features.Tournament.Queries.GetSingle
{
    public class GetSingleTournamentQuery : IRequest<GetSingleTournamentQueryResult>
    {
        public int Id { get; set; }

        public GetSingleTournamentQuery(int id)
        {
            Id = id;
        }
    }
}
