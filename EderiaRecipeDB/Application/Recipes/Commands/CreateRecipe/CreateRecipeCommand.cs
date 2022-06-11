using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe
{
    public record CreateRecipeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, int> 
    {
        private readonly IApplicationDbContext _context;
        public CreateRecipeCommandHandler(IApplicationDbContext context)
        {
                _context = context; 
        }

        public async Task<int> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
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
