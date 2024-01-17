using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TournamentProject.Features.Message.Queries.GetSingle
{
    public class GetSingleMessageQueryHandler : IRequestHandler<GetSingleMessageQuery, GetSingleMessageQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetSingleMessageQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleMessageQueryResult> Handle(GetSingleMessageQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSingleMessageQueryValidator();

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (message == null)
            {
                return null;
            }

            var messageDTO = new GetSingleMessageQueryResult.MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ReceiverId = message.ReceiverId,
                Content = message.Content,
                Readed = message.Readed,
            };

            return new GetSingleMessageQueryResult
            {
                Message = messageDTO
            };
        }
    }
}
