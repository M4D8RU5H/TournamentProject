using MediatR;
using Microsoft.AspNetCore.Mvc;
using TournamentProject.Features.User.Commands.Authenticate;
using TournamentProject.Features.User.Commands.Create;
using TournamentProject.Features.User.Commands.Delete;
using TournamentProject.Features.User.Commands.Update;
using TournamentProject.Features.User.Queries.GetAll;
using TournamentProject.Features.User.Queries.GetByUserName;
using TournamentProject.Features.User.Queries.GetSingle;
using TournamentProject.Features.User.Queries.GetUserInGameInformations;
using TournamentProject.Features.User.Queries.GetUserMatchHistory;
using TournamentProject.Features.User.Queries.GetUsersDictionaryByName;
using TournamentProject.Models;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            var command = new GetSingleUserQuery(id);

            var response = await _mediator.Send(command);


            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);

            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser(AuthenticateUserCommand command)
        {
            var response = await _mediator.Send(command);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("Username")]
        public async Task<IActionResult> GetUserByUsername(GetByUserNameQuery command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("UsersDictionary")]
        public async Task<IActionResult> GetUsersDictionaryByUsername()
        {
            var response = await _mediator.Send(new GetUsersDictionaryQuery());

            return Ok(response);
        }

        [HttpGet("UserInGameInformations/{id}")]
        public async Task<IActionResult> GetUserInGameInformations(int id)
        {
            var command = new GetUserInGameInformationsQuery(id);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("UserMatchHistory/{id}")]
        public async Task<IActionResult> GetUserMatchHistory(int id)
        {
            var command = new GetUserMatchHistoryQuery(id);

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
