using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RecipeIngridients.Commands.UpdateRecipeIngridient
{
    public record UpdateRecipeIngridientCommand : IRequest
    {
        public int Id { get; set; }
        public int IngridientId { get; set; }
        public int RecipeId { get; set; }
        public int Amount { get; set; }
    }

    public class UpdateRecipeIngridientCommandHandler : IRequestHandler<UpdateRecipeIngridientCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRecipeIngridientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRecipeIngridientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RecipeIngridients.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(request), request.Id);
            }

            entity.IngridientId = request.IngridientId;
            entity.RecipeId = request.RecipeId; 
            entity.Amount = request.Amount;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
