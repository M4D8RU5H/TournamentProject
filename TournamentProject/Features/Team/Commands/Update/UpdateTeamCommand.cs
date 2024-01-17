using MediatR;

namespace TournamentProject.Features.Team.Commands.Update
{
    public class UpdateTeamCommand : IRequest<UpdateTeamCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ratio { get; set; }  

    }
}
