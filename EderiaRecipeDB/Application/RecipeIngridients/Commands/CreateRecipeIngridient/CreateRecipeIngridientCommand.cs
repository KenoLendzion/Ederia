using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.RecipeIngridients.Commands.CreateRecipeIngridient
{
    public record CreateRecipeIngridientCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngridientId { get; set; }
    }

    public class CreateRecuoeIngridientHandler : IRequestHandler<CreateRecipeIngridientCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateRecuoeIngridientHandler(IApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<Guid> Handle(CreateRecipeIngridientCommand request, CancellationToken cancellationToken)
        {
            var entity = new RecipeIngridient
            {
                Id = request.Id,
                RecipeId = request.RecipeId,
                IngridientId = request.IngridientId
            };

            entity.AddDomainEvent(new RecipeIngridientCreatedEvent(entity));

            _context.RecipeIngridients.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id; 
        }
    }
}
