using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Team.Commands.AddTeamMember;
using TournamentProject.Features.Team.Commands.Create;
using TournamentProject.Features.Team.Commands.Delete;
using TournamentProject.Features.Team.Commands.DeleteTeamMember;
using TournamentProject.Features.Team.Commands.Update;
using TournamentProject.Features.Team.Queries.GetAll;
using TournamentProject.Features.Team.Queries.GetSingle;
using TournamentProject.Features.Team.Queries.Nowy_folder;
using TournamentProject.Features.Tournament.Queries.GetTournamentTeams;
using TournamentProject.Models;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTeams()
        {
            var response = await _mediator.Send(new GetAllTeamsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleTeam(int id)
        {
            var command = new GetSingleTeamQuery(id);
            var response = await _mediator.Send(command);
           

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        
        [HttpGet("TournamentLinked/{id}")]
        public async Task<ActionResult> GetLinkedTeamsWithTournament(int id)
        {
            var command = new GetTournamentTeamsQuery(id);
            var response = await _mediator.Send(command);
           

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(UpdateTeamCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeam(CreateTeamCommand command)
        { 
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var command = new DeleteTeamCommand(id);
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPatch("AddTeamMember")]
        public async Task<IActionResult> AddTeamMembers(AddTeamMemberCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch("DeleteTeamMember")]
        public async Task<IActionResult> DeleteTeamMembers(DeleteTeamMemberCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("UserTeams/{id}")]
        public async Task<IActionResult> GetUserTeams(int id)
        {
            var command = new GetUserTeamsQuery(id);

            var response = await _mediator.Send(command);


            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
