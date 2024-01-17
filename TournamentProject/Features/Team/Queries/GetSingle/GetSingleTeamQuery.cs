using MediatR;

namespace TournamentProject.Features.Team.Queries.GetSingle
{
    public class GetSingleTeamQuery : IRequest<GetSingleTeamQueryResult>
    {
        public int Id { get; set; }

        public GetSingleTeamQuery(int id)
        {
            Id = id;
        }
    }
}
