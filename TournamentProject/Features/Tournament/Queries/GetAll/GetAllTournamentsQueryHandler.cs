using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Tournament.Queries.GetAll
{
    public class GetAllTournamentsQueryHandler : IRequestHandler<GetAllTournamentsQuery, GetAllTournamentsQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllTournamentsQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllTournamentsQueryResult> Handle(GetAllTournamentsQuery query, CancellationToken cancellationToken)
        {
            var tournaments = await _context.Tournaments.Select(x => new GetAllTournamentsQueryResult.TournamentDto
            {
                Id = x.Id,
                Name = x.Name,
                TournamentDate = x.TournamentDate,
                MaxTeamAmount = x.MaxTeamAmount,
                Description = x.Description,
                RegistrationStarts = x.RegistrationStarts,
                RegistrationEnds = x.RegistrationEnds,
                Status = x.Status,
                LiveTransmisionEmbed = x.LiveTransmisionEmbed,
            }).ToListAsync();

            return new GetAllTournamentsQueryResult
            {
                Tournaments = tournaments
            };
        }
    }
}
