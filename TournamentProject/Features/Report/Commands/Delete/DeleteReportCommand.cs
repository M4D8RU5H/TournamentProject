using MediatR;

namespace TournamentProject.Features.Report.Commands.Delete
{
    public class DeleteReportCommand : IRequest<DeleteReportCommandResult>
    {
        public int Id { get; set; }

        public DeleteReportCommand(int id)
        {
            Id = id;
        }
    }
}
