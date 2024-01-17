using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TournamentProject.Features.Tournament.Queries.GetSingle
{
    public class GetSingleTournamentQueryHandler : IRequestHandler<GetSingleTournamentQuery, GetSingleTournamentQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetSingleTournamentQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleTournamentQueryResult> Handle(GetSingleTournamentQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSingleTournamentQueryValidator();

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (tournament == null)
            {
                return null;
            }

            var tournamentDTO = new GetSingleTournamentQueryResult.TournamentDto
            {
                Id = tournament.Id,
                Name = tournament.Name,
                TournamentDate = tournament.TournamentDate,
                MaxTeamAmount = tournament.MaxTeamAmount,
                Description = tournament.Description,
                RegistrationStarts = tournament.RegistrationStarts,
                RegistrationEnds = tournament.RegistrationEnds,
                Status = tournament.Status,
                LiveTransmisionEmbed = tournament.LiveTransmisionEmbed,
            };

            return new GetSingleTournamentQueryResult
            {
                Tournament = tournamentDTO
            };
        }
    }
}
