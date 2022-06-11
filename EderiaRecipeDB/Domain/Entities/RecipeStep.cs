using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RecipeStep : BaseAuditableEntity
    {
        public int RecipeId { get; set; }
        public string InstructionText { get; set; }
        public int SequenceNumber { get; set; }
    }
}
