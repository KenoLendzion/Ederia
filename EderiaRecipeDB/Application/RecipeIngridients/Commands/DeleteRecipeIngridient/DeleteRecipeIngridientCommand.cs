using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Events;
using MediatR;

namespace Application.RecipeIngridients.Commands.DeleteRecipeIngridient
{
    public record DeleteRecipeIngridientCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteRecipeIngridientCommandHandler : IRequestHandler<DeleteRecipeIngridientCommand>
    {
        IApplicationDbContext _context;

        public DeleteRecipeIngridientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRecipeIngridientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RecipeIngridients.FindAsync(new object[] {request.Id}, cancellationToken);

            if( entity == null )
            {
                throw new NotFoundException();
            }

            _context.RecipeIngridients.Remove(entity);
            entity.AddDomainEvent(new RecipeIngridientDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}