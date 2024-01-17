using MediatR;

namespace TournamentProject.Features.Match.Command.Create;

public class CreateMatchCommand : IRequest<CreateMatchCommandResult>
{
    public int TournamentId { get; set; }
}