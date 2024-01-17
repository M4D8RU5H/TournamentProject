using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Report.Quaries.GetSingle
{
    public class GetSingleReportQueryHandler : IRequestHandler<GetSingleReportQuery, GetSingleReportQueryResult>
    {
        private readonly TournamentDbContext _context;

        public GetSingleReportQueryHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<GetSingleReportQueryResult> Handle(GetSingleReportQuery query, CancellationToken cancellationToken)
        {
            var validator = new GetSingleReportQueryValidator();

            var result = validator.Validate(query);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (report == null)
            {
                return null;
            }

            var reportDTO = new GetSingleReportQueryResult.ReportDto
            {
                Id = report.Id,
                SenderId = report.UserId,
                Category = report.Category,
                Description = report.Description,
                Status = report.Status,
            };

            return new GetSingleReportQueryResult
            {
                Report = reportDTO
            };
        }
    }
}
