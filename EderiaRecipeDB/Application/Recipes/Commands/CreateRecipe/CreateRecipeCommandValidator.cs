using FluentValidation;

namespace Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            // Kind of useless since Id can/should never be null anyway.
            RuleFor(v => v.Id).NotEmpty();

            // 300 is a bit high. I might change it later.
            RuleFor(v => v.Name).MaximumLength(300);
        }
    }
}
