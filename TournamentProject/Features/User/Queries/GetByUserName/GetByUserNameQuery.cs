using MediatR;

namespace TournamentProject.Features.User.Queries.GetByUserName
{
    public class GetByUserNameQuery : IRequest<GetByUserNameQueryResult>
    {
        public string Phrase { get; set; }

        public GetByUserNameQuery(string phrase)
        {
            Phrase = phrase;
        }
    }
}
