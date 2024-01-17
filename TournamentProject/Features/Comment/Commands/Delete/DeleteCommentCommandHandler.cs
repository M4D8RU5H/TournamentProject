using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TournamentProject.Models;

using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using TournamentProject.Models;

namespace TournamentProject.Features.Comment.Commands.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, DeleteCommentCommandResult>
    {
        private readonly TournamentDbContext _context;

        public DeleteCommentCommandHandler(TournamentDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteCommentCommandResult> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteCommentCommandValidator();

            var result = validator.Validate(command);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == command.Id);

            if(comment == null)
            {
                return null;
            }

            _context.Comments.Remove(comment);

            _context.SaveChangesAsync();

            return new DeleteCommentCommandResult();
        }
    }
}
