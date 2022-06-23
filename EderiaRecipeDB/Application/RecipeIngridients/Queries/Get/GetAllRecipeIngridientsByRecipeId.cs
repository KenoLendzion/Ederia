using Application.Common.Interfaces;
using MediatR;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Exceptions;

namespace Application.RecipeIngridients.Queries.Get
{
    public class GetAllRecipeIngridientsByRecipeId : IRequest<List<RecipeIngridientDto>>
    {
        public int Id { get; set; }
    }


    public class GetAllRecipeIngridientsByRecipeIdHandler : IRequestHandler<GetAllRecipeIngridientsByRecipeId, List<RecipeIngridientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllRecipeIngridientsByRecipeIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<RecipeIngridientDto>> Handle(GetAllRecipeIngridientsByRecipeId request, CancellationToken cancellationToken)
        {
            var entity = _context.RecipeIngridients.Where(x => x.RecipeId == request.Id)
                .OrderBy(x => x.RecipeId)
                .ProjectTo<RecipeIngridientDto>(_mapper.ConfigurationProvider)
                .ToList();

            if( entity == null )
            {
                throw new NotFoundException();
            }

            return Task.FromResult(entity);
        }
    }
}
