using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RecipeSteps.Commands.UpdateRecipeStep
{
    public record UpdateRecipeStepCommand : IRequest 
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string InstructionText { get; set; }
        public int SquenceNumber { get; set; }
    }

    public class UpdateRecipeStepCommandHandler : IRequestHandler<UpdateRecipeStepCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRecipeStepCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRecipeStepCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RecipeSteps.FindAsync(new object[] { request.Id },cancellationToken );

            if (entity == null)
            {
                throw new NotFoundException(nameof(request), request.Id);            
            }

            entity.RecipeId = request.RecipeId;
            entity.InstructionText = request.InstructionText;
            entity.SequenceNumber = request.SquenceNumber;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
