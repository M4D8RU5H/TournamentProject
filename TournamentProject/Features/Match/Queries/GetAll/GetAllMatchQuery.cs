using MediatR;
using TournamentProject.Features.Match.Queries.GetAll;

namespace TournamentProject.Features.Match.Queries.GetAll
{
    public class GetAllMatchesQuery : IRequest<GetAllMatchesQueryResult>
    {
        public GetAllMatchesQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
