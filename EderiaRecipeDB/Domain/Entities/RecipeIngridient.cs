using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RecipeIngridient : BaseAuditableEntity
    {
        public Guid Id { get; set; } 
        public Guid RecipeId { get; set; }
        public Guid IngridientId { get; set; }
        public int? Amount { get; set; }
    }
}
