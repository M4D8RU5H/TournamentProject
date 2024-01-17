namespace TournamentProject.Features.Post.Query.GetAll;

public class GetAllPostsQueryResult
{
    public List<PostDto> Posts { get; set; }

    public class PostDto
    {
        public int Id { get; set; }
        
        public UserDto User { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public DateTime Date { get; set; }
        
        public List<CommentsDto> Comments { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }

    public class CommentsDto
    {
        public int Id { get; set; }

        public UserDto CommentAuthor { get; set; }
        
        public string Content { get; set; }
        
        public DateTime CommentDate { get; set; }
    }
}