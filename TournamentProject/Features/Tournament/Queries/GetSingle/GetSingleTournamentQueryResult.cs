namespace TournamentProject.Features.Tournament.Queries.GetSingle
{
    public class GetSingleTournamentQueryResult
    {
        public TournamentDto Tournament { get; set; }
        public class TournamentDto
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
}
