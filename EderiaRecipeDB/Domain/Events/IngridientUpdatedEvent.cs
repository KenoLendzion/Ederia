using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class IngridientUpdatedEvent : BaseEvent 
    {
        public Ingridient Ingridient { get; set; }

        public IngridientUpdatedEvent(Ingridient ingridient)
        {
            this.Ingridient = ingridient;   
        }
    }
}
