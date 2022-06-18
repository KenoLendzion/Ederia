using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class IngridientDeletedEvent
    {
        public Ingridient Ingridient { get; set; }
        public IngridientDeletedEvent(Ingridient ingridient)
        {
            Ingridient = ingridient;
        }
    }
}
