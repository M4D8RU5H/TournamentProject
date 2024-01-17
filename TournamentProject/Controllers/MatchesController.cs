using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Match.Queries.GetAll;
using TournamentProject.Features.Match.Queries.GetSingle;
using TournamentProject.Features.Match.Command.Create;
using TournamentProject.Features.Match.Command.Update;
using TournamentProject.Models;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : Controller
    {
        private readonly IMediator _mediator;

        public MatchesController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("tournamentMatches/{id}")]
        public async Task<ActionResult> GetAllMatches(int id)
        {
            var command = new GetAllMatchesQuery(id);
            var response = await _mediator.Send(command);


            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMatch(CreateMatchCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMatch(UpdateMatchCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleMatch(int id)
        {
            var command = new GetSingleMatchQuery(id);
            var response = await _mediator.Send(command);
           

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

    }
}
