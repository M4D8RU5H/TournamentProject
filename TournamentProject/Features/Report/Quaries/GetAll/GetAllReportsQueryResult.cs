namespace TournamentProject.Features.Report.Queries.GetAll
{
    public class GetAllReportsQueryResult
    {
        public List<ReportDto> Reports { get; set; }
        public class ReportDto
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int Category { get; set; }
            public string Description { get; set; }

            public DateTime Date { get; set; }
            public int Status { get; set; }

        }
    }
}
