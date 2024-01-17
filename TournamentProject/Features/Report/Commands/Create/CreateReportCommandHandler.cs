using FluentValidation;
using MediatR;
using TournamentProject.Models;

namespace TournamentProject.Features.Report.Commands.Create
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CreateReportCommandResult>
    {
        private readonly TournamentDbContext _context;

        public CreateReportCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<CreateReportCommandResult> Handle(CreateReportCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateReportCommandValidator();

            var result = validator.Validate(command);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var report = new Models.Report()
            {
                Id = command.Id,
                UserId = command.UserId,
                Category = command.Category,
                Description = command.Description,
                Status = command.Status,
                Date = DateTime.Now,
            };

            _context.Reports.Add(report);

            await _context.SaveChangesAsync();

            return new CreateReportCommandResult();
        }
    }
}
