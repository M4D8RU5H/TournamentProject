using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Features.Comment.Commands.Create;
using TournamentProject.Features.Comment.Commands.Delete;
using TournamentProject.Features.Comment.Commands.Update;
using TournamentProject.Features.Comment.Queries.GetAll;
using TournamentProject.Models;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllComments()
        {
            var response = await _mediator.Send(new GetAllCommentsQuery());

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CreateCommentCommand command)
        {
            
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand(id);
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
