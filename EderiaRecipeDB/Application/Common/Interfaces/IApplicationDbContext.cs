using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext 
    {
        DbSet<Recipe> Recipes { get; }
        DbSet<Ingridient> Ingridients { get; }
        DbSet<RecipeIngridient> RecipeIngridients { get; }
        DbSet<RecipeStep> RecipeSteps { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
