using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Message.Queries.GetAll
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, GetAllMessagesQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllMessagesQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllMessagesQueryResult> Handle(GetAllMessagesQuery query, CancellationToken cancellationToken)
        {
            var messages = await _context.Messages.Select(x => new GetAllMessagesQueryResult.MessageDto
            {
                Id = x.Id,
                SenderId = x.SenderId,
                ReceiverId = x.ReceiverId,
                Content = x.Content,
                Readed = x.Readed,
            }).ToListAsync();

            return new GetAllMessagesQueryResult
            {
                Messages = messages
            };
        }
    }
}
