using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeIngridientDeletedEvent : BaseEvent
    {
        public RecipeIngridient RecipeIngridient { get; set; }

        public RecipeIngridientDeletedEvent(RecipeIngridient recipeIngridient)
        {
            this.RecipeIngridient = recipeIngridient;   
        }
    }
}
