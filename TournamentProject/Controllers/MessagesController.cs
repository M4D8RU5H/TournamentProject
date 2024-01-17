using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Message.Commands.Create;
using TournamentProject.Features.Message.Queries.GetAll;
using TournamentProject.Features.Message.Queries.GetSingle;
using TournamentProject.Models;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMessages()
        {
            var response = await _mediator.Send(new GetAllMessagesQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleMessage(int id)
        {
            var command = new GetSingleMessageQuery(id);
            var response = await _mediator.Send(command);


            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMessage(CreateMessageCommand command)
        {

            await _mediator.Send(command);

            return Ok();
        }
    }
}