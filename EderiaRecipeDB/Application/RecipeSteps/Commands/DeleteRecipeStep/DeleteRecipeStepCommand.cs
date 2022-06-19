using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using Domain.Events;

namespace Application.RecipeSteps.Commands.DeleteRecipeStep
{
    public record DeleteRecipeStepCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteRecipeStepCommandHandler : IRequestHandler<DeleteRecipeStepCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRecipeStepCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRecipeStepCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RecipeSteps.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException();
            }

            _context.RecipeSteps.Remove(entity);
            entity.AddDomainEvent(new RecipeStepDeletedEvent(entity));
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
