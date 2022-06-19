using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Recipes.Queries.Get
{
    public record GetRecipeByIdQuery : IRequest<RecipeDto>
    {
        public int Id { get; set; }
    }

    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetRecipeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecipeDto> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Recipes
                .First(p => p.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException();
            }

            var dto = new RecipeDto
            {
                Id = entity.Id,
                Description = entity.Description,
                Name = entity.Name,
                KcalPerPortion = entity.KcalPerPortion,
                CookingTimeInMinutes = entity.CookingTimeInMinutes
            };

            return dto;
        }
    }
}
