using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Events;
using MediatR;

namespace Application.Recipes.Commands.DeleteRecipe
{
    public record DeleteRecipeCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteRecipeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Recipes.FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Recipes), request.Id);
            }
            
            _context.Recipes.Remove(entity);

            entity.AddDomainEvent(new RecipeDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
