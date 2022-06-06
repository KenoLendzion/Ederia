using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UnknownRecipeException : Exception
    {
        public UnknownRecipeException(Recipe recipe) : base($"Recipe {recipe.Id} doens't exist.")
        {

        }
    }
}
