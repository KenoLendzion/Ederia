using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Domain.Entities;
using Domain.Events;

namespace Application.RecipeSteps.Commands.CreateRecipeStep
{
    public record CreateRecipeStepCommand : IRequest<int>
    {
        public int RecipeId { get; set; }
        public string InstructionText { get; set; }
        public int SequenceNumber { get; set; }
    }

    public class CreateRecipeStepCommandHandler : IRequestHandler<CreateRecipeStepCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRecipeStepCommandHandler(IApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<int> Handle(CreateRecipeStepCommand request, CancellationToken cancellationToken)
        {
            var entity = new RecipeStep
            {
                RecipeId = request.RecipeId,
                InstructionText = request.InstructionText,
                SequenceNumber = request.SequenceNumber
            };

            entity.AddDomainEvent(new RecipeStepCreatedEvent(entity));

            _context.RecipeSteps.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
