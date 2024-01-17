using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TournamentProject.Models;

namespace TournamentProject.Features.Report.Commands.Delete
{
    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, DeleteReportCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteReportCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteReportCommandResult> Handle(DeleteReportCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteReportCommandValidator();

            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == command.Id);

            if(report == null)
            {
                return null;
            }

            _context.Reports.Remove(report);

            _context.SaveChangesAsync();

            return new DeleteReportCommandResult();
        }
    }
}
