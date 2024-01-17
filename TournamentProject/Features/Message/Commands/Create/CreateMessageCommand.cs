using MediatR;

namespace TournamentProject.Features.Message.Commands.Create
{
    public class CreateMessageCommand : IRequest<CreateMessageCommandResult>
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public bool Readed { get; set; }

    }
}
