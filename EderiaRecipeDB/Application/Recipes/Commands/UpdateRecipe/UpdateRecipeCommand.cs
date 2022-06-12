using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recipes.Commands.UpdateRecipe
{
    public record UpdateRecipeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int KcalPerPortion { get; set; }
        public int CookingTimeInMinutes { get; set; }
    }

    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Unit>
    {
        IApplicationDbContext _context;
        public async Task<Unit> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Recipes.FindAsync(new object[] { request.Id }, cancellationToken);

            if ( entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.KcalPerPortion = request.KcalPerPortion;
            entity.CookingTimeInMinutes = request.CookingTimeInMinutes;
            
            return Unit.Value;
        }
    }
}
