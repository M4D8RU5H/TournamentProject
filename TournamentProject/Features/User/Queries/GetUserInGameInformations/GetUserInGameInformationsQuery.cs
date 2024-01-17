using MediatR;
using RiotSharp;
using RiotSharp.Misc;
using TournamentProject.Models;

namespace TournamentProject.Features.User.Queries.GetUserInGameInformations
{
    public class GetUserInGameInformationsQuery : IRequest<GetUserInGameInformationsQueryResult>
    {
        public GetUserInGameInformationsQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
