using MediatR;

namespace TournamentProject.Features.Tournament.Queries.GetTournamentTeams;

public class GetTournamentTeamsQuery : IRequest<GetTournamentTeamsQueryResult>
{
    public int Id { get; set; }

    public GetTournamentTeamsQuery(int id)
    {
        Id = id;
    }
}