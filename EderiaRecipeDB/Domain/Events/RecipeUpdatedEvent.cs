using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeUpdatedEvent : BaseEvent
    {
        public Recipe Recipe { get; set; }
        public RecipeUpdatedEvent(Recipe recipe)
        {
            this.Recipe = recipe;
        }
    }
}
