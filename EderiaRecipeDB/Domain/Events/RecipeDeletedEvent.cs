using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class RecipeDeletedEvent : BaseEvent
    {
        public Recipe Recipe { get; set; }

        public RecipeDeletedEvent(Recipe recipe)
        {
            this.Recipe = recipe;
        }

    }
}
