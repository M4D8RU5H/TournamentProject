using MediatR;

namespace TournamentProject.Features.Report.Quaries.GetSingle
{
    public class GetSingleReportQuery : IRequest<GetSingleReportQueryResult>
    {
        public int Id { get; set; }

        public GetSingleReportQuery(int id)
        {
            Id = id;
        }
    }
}
