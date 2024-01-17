namespace TournamentProject.Features.Comment.Queries.GetAll
{
    public class GetAllCommentsQueryResult
    {
        public List<CommentDto> Comments { get; set; }
        public class CommentDto
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public string Content { get; set; }
            public int PostId { get; set; }
            public DateTime CommentDate { get; set; }
        }
    }
}
