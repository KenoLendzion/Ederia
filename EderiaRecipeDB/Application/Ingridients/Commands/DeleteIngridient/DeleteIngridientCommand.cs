using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingridients.Commands.DeleteIngridient
{
    public record DeleteIngridientCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteIngridentCommandHandler : IRequestHandler<DeleteIngridientCommand>
    {
        IApplicationDbContext _context;

        public DeleteIngridentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteIngridientCommand request, CancellationToken cancellationToken)
        {
            var enttity = await _context.Ingridients.FindAsync(new object[] { request.Id }, cancellationToken);
            
            if( enttity == null )
            {
                throw new NotFoundException();
            }

            _context.Ingridients.Remove(enttity);
            enttity.AddDomainEvent(new IngridientDeletedEvent(enttity));

            return Unit.Value;
        }
    }
}
