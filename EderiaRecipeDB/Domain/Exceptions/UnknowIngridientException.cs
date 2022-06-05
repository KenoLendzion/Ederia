using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UnknowIngridientException : Exception 
    {
        public UnknowIngridientException(Ingridient ingridient) : base($"Ingridient {ingridient.Id} does't exist.")
        {

        }
    }
}
