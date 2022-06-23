using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ingridients.Queries.Get
{
    public  record GetIngridientById : IRequest<IngridientDto>
    {
        public int Id { get; set; }
    }

    public class GetIngridientByIdRequestHandler : IRequestHandler<GetIngridientById, IngridientDto>
    {
        private readonly IApplicationDbContext _context;

        public GetIngridientByIdRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IngridientDto> Handle(GetIngridientById request, CancellationToken cancellationToken)
        {
            var entity = await _context.Ingridients.FindAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException();
            }

            var dto = new IngridientDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };

            return dto;
        }
    }
}
