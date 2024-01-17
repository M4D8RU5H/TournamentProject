using MediatR;

namespace TournamentProject.Features.Post.Query.GetSingle;

public class GetSinglePostQuery : IRequest<GetSinglePostQueryResult>
{
    public int Id { get; set; }

    public GetSinglePostQuery(int id)
    {
        Id = id;
    }
}