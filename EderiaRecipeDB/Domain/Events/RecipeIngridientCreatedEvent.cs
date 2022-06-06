using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeIngridientCreatedEvent : BaseEvent
    {
        public RecipeIngridient RecipeIngridient { get; set; }
        public RecipeIngridientCreatedEvent(RecipeIngridient recipeIngridient)
        {
            this.RecipeIngridient = recipeIngridient;   
        }
    }
}
