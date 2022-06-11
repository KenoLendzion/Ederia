using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Ingridients.Commands.CreateIngridient
{
    public  record CreateIngridientCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class CreateIngridientCommandHandler : IRequestHandler<CreateIngridientCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreateIngridientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateIngridientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Ingridient
            {
                Id = request.Id,
                Name = request.Name,
            };

            entity.AddDomainEvent(new IngridientCreatedEvent(entity));

            _context.Ingridients.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}