using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RecipeIngridients.Queries.Get
{
    public class RecipeIngridientDto : IMapFrom<RecipeIngridient>
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngridientId { get; set; }
        public int? Amount { get; set; }
    }
}
