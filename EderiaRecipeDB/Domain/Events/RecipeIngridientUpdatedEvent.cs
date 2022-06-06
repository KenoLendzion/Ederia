using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeIngridientUpdatedEvent : BaseEvent
    {
        public RecipeIngridient RecipeIngridient { get; set; }

        public RecipeIngridientUpdatedEvent(RecipeIngridient recipeIngridient)
        {
            this.RecipeIngridient = recipeIngridient;   
        }
    }
}
