using MediatR;

namespace TournamentProject.Features.User.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResult>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public DateTime BannedUntill { get; set; }
    }
}
