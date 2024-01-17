using MediatR;

namespace TournamentProject.Features.Report.Commands.Create
{
    public class CreateReportCommand : IRequest<CreateReportCommandResult>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}
