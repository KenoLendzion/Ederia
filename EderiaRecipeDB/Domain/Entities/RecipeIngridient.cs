using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RecipeIngridient : BaseAuditableEntity
    {
        public int RecipeId { get; set; }
        public int IngridientId { get; set; }
        public int? Amount { get; set; }
    }
}
