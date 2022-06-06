using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeStepDeletedEvent : BaseEvent
    {
        public RecipeStep RecipeStep { get; set; }

        public RecipeStepDeletedEvent(RecipeStep recipeStep)
        {
            this.RecipeStep = recipeStep;   
        }
    }
}
