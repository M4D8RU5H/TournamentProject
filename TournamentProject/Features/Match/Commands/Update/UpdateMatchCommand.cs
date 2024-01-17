using MediatR;

namespace TournamentProject.Features.Match.Command.Update;

public class UpdateMatchCommand : IRequest<UpdateMatchCommandResult>
{
    public int Id { get; set; }
    public int FirstTeamId { get; set; }
    public int SecondTeamId { get; set; }
    public int WinnerId { get; set; }
    public int Score { get; set; }
    public int TournamentId { get; set; }
    public int Phase { get; set; }
}