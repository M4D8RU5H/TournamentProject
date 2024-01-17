using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TournamentProject.Features.Post.Command.Create;
using TournamentProject.Features.Post.Command.Delete;
using TournamentProject.Features.Post.Command.Update;
using TournamentProject.Features.Post.Query.GetAll;
using TournamentProject.Features.Post.Query.GetSingle;

namespace TournamentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            var response = await _mediator.Send(new GetAllPostsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSinglePost(int id)
        {
            var command = new GetSinglePostQuery(id);
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost(CreatePostCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePost(UpdatePostCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePost(DeletePostCommand command)
        {
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}