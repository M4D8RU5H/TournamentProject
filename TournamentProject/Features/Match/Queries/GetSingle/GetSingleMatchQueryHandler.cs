using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TournamentProject.Features.Match.Queries.GetSingle
{
    public class GetSingleMatchQueryHandler : IRequestHandler<GetSingleMatchQuery, GetSingleMatchQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetSingleMatchQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleMatchQueryResult> Handle(GetSingleMatchQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSingleMatchQueryValidator();

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var match = await _context.Matches.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (match == null)
            {
                return null;
            }
            GetSingleMatchQueryResult.MatchDto matchDTO;

            if (match.WinnerId!=null)
            {
                matchDTO = new GetSingleMatchQueryResult.MatchDto
                {
                    Id = match.Id,
                    FirstTeamId = match.FirstTeamId,
                    SecondTeamId = match.SecondTeamId,
                    WinnerId = (int)match.WinnerId,
                    Score = match.Score,
                    TournamentId = match.TournamentId,
                    Phase = match.Phase,
                };
            }
            else
            {
                matchDTO = new GetSingleMatchQueryResult.MatchDto
                {
                    Id = match.Id,
                    FirstTeamId = match.FirstTeamId,
                    SecondTeamId = match.SecondTeamId,
                   // WinnerId = (int)match.WinnerId,
                    Score = match.Score,
                    TournamentId = match.TournamentId,
                    Phase = match.Phase,
                };
            }


            return new GetSingleMatchQueryResult
            {
                Match = matchDTO
            };
        }
    }
}
