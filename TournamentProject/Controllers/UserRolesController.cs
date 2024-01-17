using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentProject.Features.UserRole.Commands.Create;
using TournamentProject.Features.UserRole.Commands.Delete;
using TournamentProject.Features.UserRole.Commands.Update;
using TournamentProject.Features.UserRole.Queries.GetAll;
using TournamentProject.Features.UserRole.Queries.GetSingle;
using TournamentProject.Models;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : Controller
    {
        private readonly IMediator _mediator;

        public UserRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var response = await _mediator.Send(new GetAllUserRolesQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUserRole(int id)
        {
            var command = new GetSingleUserRoleQuery(id);

            var response = await _mediator.Send(command);


            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRole(CreateUserRoleCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var command = new DeleteUserRoleCommand(id);

            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
