using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Report.Commands.Create;
using TournamentProject.Features.Report.Commands.Delete;
using TournamentProject.Features.Report.Quaries.GetSingle;
using TournamentProject.Features.Report.Queries.GetAll;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReports()
        {
            var response = await _mediator.Send(new GetAllReportsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleReport(int id)
        {
            var command = new GetSingleReportQuery(id);
            var response = await _mediator.Send(command);


            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReport(CreateReportCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var command = new DeleteReportCommand(id);
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}