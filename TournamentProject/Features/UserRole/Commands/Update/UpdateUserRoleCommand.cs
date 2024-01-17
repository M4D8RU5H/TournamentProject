using MediatR;

namespace TournamentProject.Features.UserRole.Commands.Update
{
    public class UpdateUserRoleCommand : IRequest<UpdateUserRoleCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
