using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Tournament.Commands.AddTournamentTeam;
using TournamentProject.Features.Tournament.Commands.Create;
using TournamentProject.Features.Tournament.Commands.Delete;
using TournamentProject.Features.Tournament.Commands.DeleteTournamentTeam;
using TournamentProject.Features.Tournament.Commands.Update;
using TournamentProject.Features.Tournament.Queries.GetAll;
using TournamentProject.Features.Tournament.Queries.GetSingle;
using TournamentProject.Models;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            var response = await _mediator.Send(new GetAllTournamentsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {
            var command = new GetSingleTournamentQuery(id);

            var response = await _mediator.Send(command);


            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(UpdateTournamentCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostTournament(CreateTournamentCommand command)
        {

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var command = new DeleteTournamentCommand(id);

            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPatch("AddTournamentTeam")]
        public async Task<IActionResult> AddTournamentTeam(AddTournamentTeamCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch("DeleteTournamentTeam")]
        public async Task<IActionResult> DeleteTournamentTeam(DeleteTournamentTeamCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
