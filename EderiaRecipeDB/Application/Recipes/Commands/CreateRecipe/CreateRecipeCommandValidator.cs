using FluentValidation;

namespace Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            // TODO CreateRecipeCommandValidator

            // 300 is a bit high. I might change it later.
            RuleFor(v => v.Name).MaximumLength(300);
        }
    }
}
