using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Report.Queries.GetAll
{
    public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, GetAllReportsQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetAllReportsQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllReportsQueryResult> Handle(GetAllReportsQuery query, CancellationToken cancellationToken)
        {
            var reports = await _context.Reports.Select(x => new GetAllReportsQueryResult.ReportDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Category = x.Category,
                Description = x.Description,
                Date = DateTime.Now,
                Status = x.Status,
            }).ToListAsync();

            return new GetAllReportsQueryResult
            {
                Reports = reports
            };
        }
    }
}
