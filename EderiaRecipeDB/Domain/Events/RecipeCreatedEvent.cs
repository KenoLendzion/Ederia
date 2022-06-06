using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeCreatedEvent : BaseEvent
    {
        public Recipe Recipe { get; set; }

        public RecipeCreatedEvent(Recipe recipe)
        {
            this.Recipe = recipe;
        }
    }
}
