using MediatR;
using TournamentProject.Features.Team.Queries.GetUserTeams;

namespace TournamentProject.Features.Team.Queries.Nowy_folder
{
    public class GetUserTeamsQuery : IRequest<GetUserTeamsQueryResult>
    {
        public GetUserTeamsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
