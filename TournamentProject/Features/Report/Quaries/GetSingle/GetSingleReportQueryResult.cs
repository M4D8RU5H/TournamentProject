namespace TournamentProject.Features.Report.Quaries.GetSingle
{
    public class GetSingleReportQueryResult
    {
        public ReportDto Report { get; set; }
        public class ReportDto
        {
            public int Id { get; set; }
            public int SenderId { get; set; }
            public int Category { get; set; }
            public string Description { get; set; }
            public int Status { get; set; }
        }
    }
}
