using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe
{
    public record CreateRecipeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid> 
    {
        private readonly IApplicationDbContext _context;

        public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Recipe
            {
                Id = request.Id,
                Name = request.Name,
            };

            entity.AddDomainEvent(new RecipeCreatedEvent(entity));

            _context.Recipes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
