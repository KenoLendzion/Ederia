using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingridients.Commands.UpdateIngridient
{
    public record UpdateIngridientCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateIngridientCommandHandler : IRequestHandler<UpdateIngridientCommand, Unit>
    {
        IApplicationDbContext _context;
        public async Task<Unit> Handle(UpdateIngridientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Ingridients.FindAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            entity.Name = request.Name; 
            entity.Description = request.Description;

            return Unit.Value;
        }
    }
}
