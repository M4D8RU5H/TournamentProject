using MediatR;

namespace TournamentProject.Features.Tournament.Commands.Create
{
    public class CreateTournamentCommand : IRequest<CreateTournamentCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentDate { get; set; }
        public int MaxTeamAmount { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationStarts { get; set; }
        public DateTime RegistrationEnds { get; set; }
        public int Status { get; set; }
        public string LiveTransmisionEmbed { get; set; }
    }
}
