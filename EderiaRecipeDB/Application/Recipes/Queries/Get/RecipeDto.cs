using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recipes.Queries.Get
{
    public class RecipeDto : IMapFrom<Recipe>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int KcalPerPortion { get; set; }
        public int CookingTimeInMinutes { get; set; }
    }
}
