using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.RecipeIngridients.Commands.CreateRecipeIngridient
{
    public record CreateRecipeIngridientCommand : IRequest<int>
    {
        public int RecipeId { get; set; }
        public int IngridientId { get; set; }
        public int? Amount { get; set; } = 0;
    }

    public class CreateRecipeIngridientHandler : IRequestHandler<CreateRecipeIngridientCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRecipeIngridientHandler(IApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<int> Handle(CreateRecipeIngridientCommand request, CancellationToken cancellationToken)
        {
            var entity = new RecipeIngridient
            {
                RecipeId = request.RecipeId,
                IngridientId = request.IngridientId,
                Amount = request.Amount
            };

            entity.AddDomainEvent(new RecipeIngridientCreatedEvent(entity));

            _context.RecipeIngridients.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id; 
        }
    }
}
