using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeStepUpdatedEvent : BaseEvent
    {
        RecipeStep RecipeStep { get; set; }

        public RecipeStepUpdatedEvent(RecipeStep recipeStep)
        {
            this.RecipeStep = recipeStep;
        }
    }
}
